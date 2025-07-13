using SkyForge.Reactive;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerViewModel : IPlayerViewModel
    {
        public ReactiveProperty<Vector3> Position => _playerModel.Position;

        private IPlayerModel _playerModel;
        private IPlayerService _playerService;
        
        public PlayerViewModel(IPlayerModel playerModel, IPlayerService playerService)
        {
            _playerModel = playerModel;
            _playerService = playerService;
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
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
        
    }
}