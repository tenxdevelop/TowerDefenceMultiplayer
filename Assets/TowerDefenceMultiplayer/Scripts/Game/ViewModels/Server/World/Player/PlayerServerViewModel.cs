using SkyForge.Reactive;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerServerViewModel : IPlayerServerViewModel
    {
        public ReactiveProperty<Vector3> Position => _playerModel.Position;

        private IPlayerModel _playerModel;
        private IPlayerService _playerService;
        
        public PlayerServerViewModel(IPlayerModel playerModel, IPlayerService playerService)
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
            Debug.Log("Player server update");
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
        
    }
}