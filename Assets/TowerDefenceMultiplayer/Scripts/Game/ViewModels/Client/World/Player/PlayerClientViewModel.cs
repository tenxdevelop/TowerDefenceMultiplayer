using SkyForge.MVVM;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerClientViewModel : ViewModel, IPlayerClientViewModel
    {
        public ulong GetClientId() => 0;
        
        public void OnNetworkSpawn()
        {
            
        }
        
        public void OnNetworkDespawn()
        {
            
        }
        
        public override void PhysicsUpdate(float deltaTime)
        {
            
        }
        
    }
}