using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using SkyForge.Reactive;
using SkyForge.MVVM;
using Unity.Netcode;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class VMCollectionToNetworkGameObjectCreationBinder : Binder
    {
        [SerializeField] private BaseNetworkView _prefabNetworkView;

        private Dictionary<INetworkViewModel, BaseNetworkView> _networkViewModelsMap = new();
        
        protected override IBinding BindInternal(IViewModel viewModel)
        {
            var viewModelType = viewModel.GetType();
            
            if (viewModelType.FullName.Equals(ViewModelTypeFullName))
            {
                var propertyInfo = viewModelType.GetProperty(PropertyName);
                var collectionNetworkViewModels = propertyInfo.GetValue(viewModel) as IObservableCollection<INetworkViewModel>;
                var handle = collectionNetworkViewModels.Subscribe(OnNetworkViewModelAdded, OnNetworkViewModelRemoved, OnNetworkVIewModelClear);
                return handle;
            }
            return null;
        }

        private void OnNetworkVIewModelClear()
        {
            foreach (var baseNetworkView in _networkViewModelsMap.Values)
            {
                Destroy(baseNetworkView.gameObject);
            }
            
            _networkViewModelsMap.Clear();
        }

        private void OnNetworkViewModelRemoved(INetworkViewModel networkViewModel)
        {
            if (_networkViewModelsMap.TryGetValue(networkViewModel, out var baseNetworkView))
            {
                Destroy(baseNetworkView.gameObject);
                _networkViewModelsMap.Remove(networkViewModel);
            }
        }

        private void OnNetworkViewModelAdded(INetworkViewModel networkViewModel)
        {
            var newNetworkView = Instantiate(_prefabNetworkView);
            _networkViewModelsMap[networkViewModel] = newNetworkView;
            
            newNetworkView.Bind(networkViewModel);
            
            var networkObject = newNetworkView.GetComponent<NetworkObject>();
            networkObject.SpawnAsPlayerObject(networkViewModel.GetClientId(), true);
            
        }
    }
}
