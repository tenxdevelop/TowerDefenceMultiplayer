using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using Unity.Netcode;
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
            
            LobbyRegisterServices.RegisterServices(_container, lobbyEnterParams, _lobbyExitParams);
            LobbyRegisterViewModels.RegisterViewModels(_container, lobbyEnterParams);
            LobbyRegisterViews.RegisterViews(_container);
            
            yield return null;
            
            var loadService = _container.Resolve<LoadService>();
            
            var prefabNetworkManager = loadService.LoadPrefab<NetworkManager>(LoadService.PREFAB_NETWORK_MANAGER);
            var networkManager = loadService.CreateGameObject(prefabNetworkManager);
            DontDestroyOnLoad(networkManager.gameObject);
            
            
            if (lobbyEnterParams.IsHost)
            {
                networkManager.StartHost();
            }
            else
            {
                networkManager.StartClient();
            }
        }

        public override void OnNetworkSpawn()
        {
            if (IsServer)
            {
                NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            }
        }
        
        public override void OnNetworkDespawn()
        {
            if (IsServer)
            {
                NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
            }
        }

        public IObservable<SceneExitParams> Run()
        {
            return _lobbyExitParams;
        }
        
        private void OnClientConnected(ulong clientId)
        {
            var playerService = _container.Resolve<IPlayerService>();
            playerService.CreatePlayer(clientId, "", GetRandomPositionSpawn());
        }

        private Vector3 GetRandomPositionSpawn()
        {
            var randomPositionX = Random.Range(-10f, 10f);
            var randomPositionZ = Random.Range(-10f, 10f);
            
            return  new Vector3(randomPositionX, 1f, randomPositionZ);
        }
    }
}