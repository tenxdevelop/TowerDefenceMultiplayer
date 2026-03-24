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
        
    }
}