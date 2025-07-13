using SkyForge.MVVM;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerClientView : NetworkClientView
    {
        [SerializeField] private Transform _playerCamera;
        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                _playerCamera.gameObject.SetActive(true);
                ClientNetworkService.Instance.OnCreatedNetworkClientView(this);
            }
        }
    }
}