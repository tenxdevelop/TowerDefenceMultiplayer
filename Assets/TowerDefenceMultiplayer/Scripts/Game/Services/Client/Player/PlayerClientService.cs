using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerClientService : IPlayerClientService
    {
        private readonly NetworkService _networkService;

        public PlayerClientService(NetworkService networkService)
        {
            _networkService = networkService;
        }
        
        public void UpdatePlayerMoveDirection(ulong clientId, Vector2 direction)
        {
            var writer = new FastBufferWriter(sizeof(float) * 2, Allocator.Temp);
            writer.WriteValueSafe(direction);
            
            _networkService.ClientSendNamedMessage(PlayerService.PLAYER_MOVE_DIRECTION_UPDATE_SERVER_RPC, writer);
        }
        
        public void Dispose()
        {
            
        }
    }
}