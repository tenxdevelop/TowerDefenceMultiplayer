using System;

namespace TowerDefenceMultiplayer
{
    public interface IEntityViewModelFactoryService : IDisposable
    {
        public IEntityViewModel CreateEntityViewModel(IEntityStateModel entityStateModel);
    }
}