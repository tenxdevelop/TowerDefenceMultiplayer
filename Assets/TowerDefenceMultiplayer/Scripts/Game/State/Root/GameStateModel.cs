using SkyForge.Reactive.Extention;
using System.Collections.Generic;
using SkyForge.Reactive;
using System.Linq;

namespace TowerDefenceMultiplayer
{
    public class GameStateModel : IGameStateModel
    {
        public GameStateData OriginState { get; }
        
        public ReactiveCollection<IEntityStateModel> Entities { get; private set; }

        private IEntityFactoryService _entityFactoryService;

        public GameStateModel(GameStateData originState, IEntityFactoryService entityFactoryService)
        {
            _entityFactoryService = entityFactoryService;
            
            OriginState = originState;
            
            UpdateGameState(originState);
        }

        public int GetEntityId()
        {
            return OriginState.globalEntityId++;
        }
        
        private void UpdateGameState(GameStateData originState)
        {
            UpdateEntities(originState.entities);
        }

        private void UpdateEntities(List<EntityStateData> entityStateData)
        {
            Entities = new ReactiveCollection<IEntityStateModel>();
            
            foreach (var entityDataOrigin in entityStateData)
            {
                var entityModel = _entityFactoryService.CreateEntityModel(entityDataOrigin);
                Entities.Add(entityModel);
            }

            Entities.Subscribe(OnEntitiesAdded, OnEntitiesRemoved, OnEntitiesClear);
        }

        private void OnEntitiesClear()
        {
            OriginState.entities.Clear();
        }

        private void OnEntitiesRemoved(IEntityStateModel entityStateModel)
        {
            var entityDelete = OriginState.entities.FirstOrDefault(entityStateData => entityStateData.uniqueId.Equals(entityStateModel.UniqueId));
            OriginState.entities.Remove(entityDelete);
        }

        private void OnEntitiesAdded(IEntityStateModel entityStateModel)
        {
            var entityStateData = _entityFactoryService.GetEntityStateData(entityStateModel);
            OriginState.entities.Add(entityStateData);
        }
    }
}