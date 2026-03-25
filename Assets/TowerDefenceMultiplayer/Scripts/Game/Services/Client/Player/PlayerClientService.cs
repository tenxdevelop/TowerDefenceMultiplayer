using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerClientService : IPlayerClientService
    {
        
        public void UpdatePlayerMoveDirection(ulong clientId, Vector2 direction)
        {
            var writer = new FastBufferWriter(sizeof(float) * 2, Allocator.Temp);
            
            writer.WriteValueSafe(direction);
            
            NetworkManager.Singleton.CustomMessagingManager.SendNamedMessage(PlayerService.PLAYER_MOVE_DIRECTION_UPDATE_SERVER_RPC, clientId, writer);
        }
        
        public void Dispose()
        {
            
        }
    }
}