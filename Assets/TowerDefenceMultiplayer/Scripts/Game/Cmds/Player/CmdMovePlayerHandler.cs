using System.Linq;
using SkyForge.Command;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class CmdMovePlayerHandler : ICommandHandler<CmdMovePlayer>
    {
        private readonly GameStateModel _gameStateModel;

        public CmdMovePlayerHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdMovePlayer command)
        {
            if (command.Direction.Equals(Vector2.zero))
                return false;
            
            var player = _gameStateModel.Entities.Where(entity => entity.UniqueId.Equals(command.EntityId)).FirstOrDefault() as IPlayerModel;

            if (player is null)
                return false;

            var speed = 12f;
            player.Position.Value += new Vector3(speed * command.Direction.x * command.DeltaTime, 0, speed * command.Direction.y * command.DeltaTime);
            
            return true;
        }
    }
}