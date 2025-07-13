using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using Unity.Netcode;
using SkyForge.MVVM;
using UnityEngine;
using SkyForge;

namespace TowerDefenceMultiplayer
{
    public class LobbyEntryPoint : NetworkBehaviour, IEntryPoint
    {
        private SingleReactiveProperty<LobbyExitParams> _lobbyExitParams = new();
        
        private DIContainer _container;
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            var lobbyEnterParams = sceneEnterParams as LobbyEnterParams;
            _container = parentContainer;

            var loadService = _container.Resolve<LoadService>();
            var prefabNetworkManager = loadService.LoadPrefab<NetworkManager>(LoadService.PREFAB_NETWORK_MANAGER);
            var networkManager = loadService.CreateGameObject(prefabNetworkManager);
            DontDestroyOnLoad(networkManager.gameObject);
            
            if (lobbyEnterParams.IsHost)
            {
                
                LobbyRegisterServices.RegisterServerServices(_container, lobbyEnterParams, _lobbyExitParams);
                LobbyRegisterViewModels.RegisterServerViewModels(_container, lobbyEnterParams);
                LobbyRegisterViews.RegisterServerViews(_container);
                
                LobbyRegisterServices.RegisterClientServices(_container, lobbyEnterParams,  _lobbyExitParams);
                LobbyRegisterViewModels.RegisterClientViewModels(_container, lobbyEnterParams);
                LobbyRegisterViews.RegisterClientViews(_container);
                
                ClientNetworkService.Instance.NetworkClientViewCreatedEvent += OnNetworkClientViewCreated;
                
                networkManager.StartHost();
            }
            else
            {
                LobbyRegisterServices.RegisterClientServices(_container, lobbyEnterParams,  _lobbyExitParams);
                LobbyRegisterViewModels.RegisterClientViewModels(_container, lobbyEnterParams);
                LobbyRegisterViews.RegisterClientViews(_container);
                
                ClientNetworkService.Instance.NetworkClientViewCreatedEvent += OnNetworkClientViewCreated;
                
                networkManager.StartClient();
            }

            yield return null;
            
        }

        public override void OnNetworkSpawn()
        {
            if (IsServer)
            {
                NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedInServer;
            }
            
        }
        
        public override void OnNetworkDespawn()
        {
            if (IsServer)
            {
                NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnectedInServer;
            }

            if (IsClient)
            {
                ClientNetworkService.Instance.NetworkClientViewCreatedEvent -= OnNetworkClientViewCreated;
            }
        }

        public IObservable<SceneExitParams> Run()
        {
            return _lobbyExitParams;
        }
        
        private void OnClientConnectedInServer(ulong clientId)
        {
            var playerService = _container.Resolve<IPlayerService>();
            playerService.CreatePlayer(clientId, "", GetRandomPositionSpawn());
        }

        private void OnNetworkClientViewCreated(NetworkClientView networkClientView)
        {
            var clientFactoryViewModel = _container.Resolve<ClientFactoryViewModel>();
            var networkClientViewModel = clientFactoryViewModel.CreateNetworkClientViewModel(networkClientView);
            networkClientView.Bind(networkClientViewModel);
        }

        private Vector3 GetRandomPositionSpawn()
        {
            var randomPositionX = Random.Range(-10f, 10f);
            var randomPositionZ = Random.Range(-10f, 10f);
            
            return  new Vector3(randomPositionX, 1f, randomPositionZ);
        }
    }
}