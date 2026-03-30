using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using SkyForge.Reactive;
using SkyForge.MVVM;
using Unity.Netcode;
using UnityEngine;
using System.Linq;

namespace TowerDefenceMultiplayer
{
    public class EntityVMCollectionToNetworkGameObjectCreationBinder : Binder
    {
        [SerializeField] private List<EntityTypePrefabCreation> _prefabNetworkViews;

        private Dictionary<IEntityViewModel, BaseNetworkView> _networkViewModelsMap = new();
        
        protected override IBinding BindInternal(IViewModel viewModel)
        {
            var viewModelType = viewModel.GetType();
            
            if (viewModelType.FullName.Equals(ViewModelTypeFullName))
            {
                var propertyInfo = viewModelType.GetProperty(PropertyName);
                var collectionNetworkViewModels = propertyInfo.GetValue(viewModel) as IObservableCollection<IEntityViewModel>;
                var handle = collectionNetworkViewModels.Subscribe(OnEntityViewModelAdded, OnEntityViewModelRemoved, OnEntityViewModelClear);
                return handle;
            }
            return null;
        }

        private void OnEntityViewModelClear()
        {
            foreach (var baseNetworkView in _networkViewModelsMap.Values)
            {
                Destroy(baseNetworkView.gameObject);
            }
            
            _networkViewModelsMap.Clear();
        }

        private void OnEntityViewModelRemoved(IEntityViewModel entityViewModel)
        {
            if (_networkViewModelsMap.TryGetValue(entityViewModel, out var baseNetworkView))
            {
                Destroy(baseNetworkView.gameObject);
                _networkViewModelsMap.Remove(entityViewModel);
            }
        }

        private void OnEntityViewModelAdded(IEntityViewModel entityViewModel)
        {
            var prefabNetworkView = _prefabNetworkViews
                .Where(entityPrefab => entityPrefab.EntityType.Equals(entityViewModel.EntityType)).Select(entityPrefab => entityPrefab.Prefab).FirstOrDefault();

            if (prefabNetworkView is null)
            {
                Debug.Log($"not found prefab for creation entity view by entity type: {entityViewModel.EntityType}");
                return;
            }
            
            var newNetworkView = Instantiate(prefabNetworkView);  
            _networkViewModelsMap[entityViewModel] = newNetworkView;
            newNetworkView.Bind(entityViewModel);
            var networkObject = newNetworkView.GetComponent<NetworkObject>();
            networkObject.SpawnAsPlayerObject(entityViewModel.GetClientId(), true);
            
        }
    }
}
