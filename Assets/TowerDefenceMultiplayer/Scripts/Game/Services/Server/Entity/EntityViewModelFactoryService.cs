using SkyForge;
using System;

namespace TowerDefenceMultiplayer
{
    public class EntityViewModelFactoryService : IEntityViewModelFactoryService
    {

        private readonly DIContainer _gameplayContainer;

        public EntityViewModelFactoryService(DIContainer gameplayContainer)
        {
            _gameplayContainer = gameplayContainer;
        }
        
        public IEntityViewModel CreateEntityViewModel(IEntityStateModel entityStateModel)
        {
            switch (entityStateModel.EntityType)
            {
                case EntityType.Player:
                    var playerModel = entityStateModel as IPlayerModel;
                    return new PlayerServerViewModel(playerModel, _gameplayContainer.Resolve<IPlayerService>());
                default:
                    throw new NotImplementedException($"not implemented create entity view model factory method for entity type: {entityStateModel.EntityType}");
            }
        }
        
        public void Dispose()
        {
            
        }
        
    }
}