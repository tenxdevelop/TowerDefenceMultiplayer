using SkyForge.Command;

namespace TowerDefenceMultiplayer
{
    public class CmdCreatePlayerHandler : ICommandHandler<CmdCreatePlayer>
    {
        private readonly GameStateModel _gameStateModel;
        
        private IEntityFactoryService _entityFactoryService;
        
        public CmdCreatePlayerHandler(GameStateModel gameStateModel, IEntityFactoryService entityFactoryService)
        {
            _gameStateModel = gameStateModel;
            _entityFactoryService =  entityFactoryService;
        }
        
        public bool Handle(CmdCreatePlayer command)
        {
            var entityId = _gameStateModel.GetEntityId();
            
            var newPlayerData = new PlayerData()
            {
                clientId = command.ClientId,
                healthPoint =  100,
                entityType = EntityType.Player,
                uniqueId = entityId,
                position = command.Position,
                configId = command.ConfigId
            };
            
            var entityStateModel = _entityFactoryService.CreateEntityModel(newPlayerData);
            
            _gameStateModel.Entities.Add(entityStateModel);
            
            return true;
        }
    }
}