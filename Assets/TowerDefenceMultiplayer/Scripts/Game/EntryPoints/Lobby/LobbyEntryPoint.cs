using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using Unity.Netcode;
using UnityEngine;
using SkyForge;

namespace TowerDefenceMultiplayer
{
    public class LobbyEntryPoint : MonoBehaviour, IEntryPoint
    {
        private SingleReactiveProperty<LobbyExitParams> _lobbyExitParams = new();
        
        private DIContainer _container;
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            var lobbyEnterParams = sceneEnterParams as LobbyEnterParams;
            _container = parentContainer;
            
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

        public IObservable<SceneExitParams> Run()
        {
            return _lobbyExitParams;
        }
    }
}