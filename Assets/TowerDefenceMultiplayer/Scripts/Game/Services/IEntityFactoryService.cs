using System;

namespace TowerDefenceMultiplayer
{
    public interface IEntityFactoryService : IDisposable
    {
        public IEntityStateModel CreateEntityModel(EntityStateData entityStateData);
        public EntityStateData GetEntityStateData(IEntityStateModel entityStateModel);
        
    }
}