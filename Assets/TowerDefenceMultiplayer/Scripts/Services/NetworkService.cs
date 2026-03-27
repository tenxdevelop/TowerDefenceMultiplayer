using Unity.Netcode;
using System;

namespace TowerDefenceMultiplayer
{
    public class NetworkService : IDisposable
    {
        private readonly NetworkManager _networkManager;

        public NetworkService(NetworkManager networkManager)
        {
            _networkManager = networkManager;
        }

        public void RegisterNamedHandler(string methodName, CustomMessagingManager.HandleNamedMessageDelegate handler)
        {
            _networkManager.CustomMessagingManager.RegisterNamedMessageHandler(methodName, handler);
        }

        public void UnregisterNamedHandler(string methodName)
        {
            _networkManager.CustomMessagingManager.UnregisterNamedMessageHandler(methodName);
        }

        public void ClientSendNamedMessage(string messageName, FastBufferWriter writer)
        {
            var serverClientId = NetworkManager.ServerClientId;
            NetworkManager.Singleton.CustomMessagingManager.SendNamedMessage(messageName, serverClientId, writer);
        }
        
        public void Dispose()
        {
            
        }
    }
}