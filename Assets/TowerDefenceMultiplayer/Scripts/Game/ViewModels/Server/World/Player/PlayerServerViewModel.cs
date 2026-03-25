using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerServerViewModel : ViewModel, IPlayerServerViewModel
    {
        public ReactiveProperty<Vector3> Position => _playerModel.Position;

        private readonly IPlayerModel _playerModel;
        private readonly IPlayerService _playerService;

        private Vector2 _directionMove;
        
        public PlayerServerViewModel(IPlayerModel playerModel, IPlayerService playerService)
        {
            _playerModel = playerModel;
            _playerService = playerService;
            
            _directionMove = Vector2.zero;
        }
        
        public void OnNetworkSpawn()
        {
            
        }

        public void OnNetworkDespawn()
        {
            
        }

        public ulong GetClientId()
        {
            return _playerModel.ClientId;
        }

        public void UpdateMoveDirection(Vector2 direction)
        {
            _directionMove = direction;
            Debug.Log("player update direction move in server: " + direction);
        }
    }
}