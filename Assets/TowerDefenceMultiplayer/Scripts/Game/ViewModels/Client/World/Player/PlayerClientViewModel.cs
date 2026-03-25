using System.Collections.Generic;
using SkyForge.MVVM;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerClientViewModel : ViewModel, IPlayerClientViewModel
    {

        private readonly IPlayerInput _playerInput;
        private readonly IPlayerClientService _playerClientService;
        
        public PlayerClientViewModel(IList<IPlayerInput> playerInputs, IPlayerClientService playerClientService)
        {
            _playerInput = playerInputs.First();
            _playerInput.PlayerMovedEvent += OnPlayerMoved;
            _playerClientService = playerClientService;
        }
        
        public ulong GetClientId() => 0;
        
        public void OnNetworkSpawn()
        {
            
        }
        
        public void OnNetworkDespawn()
        {
            _playerInput.PlayerMovedEvent -= OnPlayerMoved;
        }
        
        private void OnPlayerMoved(Vector2 direction)
        {
            var clientId = NetworkManager.Singleton.LocalClientId;
            _playerClientService.UpdatePlayerMoveDirection(clientId, direction);
        }
    }
}