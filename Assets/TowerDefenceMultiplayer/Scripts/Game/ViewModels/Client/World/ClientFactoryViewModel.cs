using SkyForge.MVVM;
using SkyForge;
using System;

namespace TowerDefenceMultiplayer
{
    public class ClientFactoryViewModel : IDisposable
    {
        private DIContainer _container;

        public ClientFactoryViewModel(DIContainer container)
        {
            _container = container;
        }
        
        public INetworkViewModel CreateNetworkClientViewModel(NetworkClientView networkClientView)
        {
            switch (networkClientView)
            {
                case PlayerClientView playerClientView:
                    return _container.Resolve<IPlayerClientViewModel>();
                default:
                    throw new NotImplementedException($"network client factory view model not implemented network client view of type: {networkClientView.GetType().Name}");
            }
        }
        
        
        public void Dispose()
        {
            
        }
    }
}