
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerClientViewModel : IPlayerClientViewModel
    {
        
        public void OnNetworkSpawn()
        {
           
        }
        
        public void OnNetworkDespawn()
        {
            
        }
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            Debug.Log("Player client update");
        }

        public ulong GetClientId()
        {
            return 0;
        }
        
    }
}