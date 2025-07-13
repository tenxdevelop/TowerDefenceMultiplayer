using SkyForge.MVVM;
using System;

namespace TowerDefenceMultiplayer
{
    public class ClientNetworkService : IDisposable
    {
        public static ClientNetworkService Instance => _instance is null ? new ClientNetworkService() : _instance;
        
        private static ClientNetworkService _instance;

        public event Action<NetworkClientView> NetworkClientViewCreatedEvent;
        private ClientNetworkService()
        {
            _instance = this;
        }

        public void OnCreatedNetworkClientView(NetworkClientView networkClientView)
        {
            NetworkClientViewCreatedEvent?.Invoke(networkClientView);
        }
        
        public void Dispose()
        {
            
        }
    }
}