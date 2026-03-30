using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class MapViewModel : ViewModel, IMapViewModel
    {
        public ReactiveCollection<IEntityViewModel> Entities { get; private set; }
        
        private readonly Dictionary<int, IEntityViewModel> _entitiesMap;
        private readonly List<IEntityViewModelHasherService> _entityViewModelHasherService;
        
        private readonly IEntityViewModelFactoryService _entityFactoryService;
        
        public MapViewModel(IGameStateProvider gameStateProvider, IEntityViewModelFactoryService entityFactoryService)
        {
            _entityViewModelHasherService = new List<IEntityViewModelHasherService>();
            _entitiesMap = new Dictionary<int, IEntityViewModel>();
            
            _entityFactoryService = entityFactoryService;
            
            var entities = gameStateProvider.StateModel.Entities;
            UpdateEntities(entities);
        }
        
        public void AttachEntityHasherService(IEntityViewModelHasherService entityHasherService)
        {
            _entityViewModelHasherService.Add(entityHasherService);
        }

        public void DetachEntityHasherService(IEntityViewModelHasherService entityHasherService)
        {
            if (_entityViewModelHasherService.Contains(entityHasherService))
                _entityViewModelHasherService.Remove(entityHasherService);
        }
        
        private void UpdateEntities(ReactiveCollection<IEntityStateModel> entities)
        {
            Entities = new ReactiveCollection<IEntityViewModel>();

            foreach (var entityStateModel in entities)
                CreateEntityViewModel(entityStateModel);
            
            entities.Subscribe(CreateEntityViewModel, RemoveEntityViewModel, OnClearEntities);
        }

        private void CreateEntityViewModel(IEntityStateModel entityStateModel)
        {
            var entityViewModel = _entityFactoryService.CreateEntityViewModel(entityStateModel);
            Entities.Add(entityViewModel);
            _entitiesMap[entityStateModel.UniqueId] = entityViewModel;
            
            foreach(var entityViewModelHasherService in _entityViewModelHasherService)
                entityViewModelHasherService.OnCreateEntityViewModel(entityStateModel, entityViewModel);
        }

        private void RemoveEntityViewModel(IEntityStateModel entityStateModel)
        {
            if (_entitiesMap.TryGetValue(entityStateModel.UniqueId, out var entityViewModelDelete))
            {
                Entities.Remove(entityViewModelDelete);
                _entitiesMap.Remove(entityStateModel.UniqueId);

                foreach (var entityViewModelHasherService in _entityViewModelHasherService)
                    entityViewModelHasherService.OnRemoveEntityViewModel(entityStateModel);
            }
        }

        private void OnClearEntities()
        {
            Entities.Clear();
            _entitiesMap.Clear();
            
            foreach(var entityViewModelHasherService in _entityViewModelHasherService)
                entityViewModelHasherService.OnClearEntities();
        }
    }
}