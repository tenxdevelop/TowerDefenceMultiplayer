using SkyForge.Command;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class CmdMovePlayer : ICommand
    {
        public readonly int EntityId;
        public readonly Vector2 Direction;
        public readonly float DeltaTime;

        public CmdMovePlayer(int entityId, Vector2 direction, float deltaTime)
        {
            EntityId = entityId;
            Direction = direction;
            DeltaTime = deltaTime;
        }
    }
}