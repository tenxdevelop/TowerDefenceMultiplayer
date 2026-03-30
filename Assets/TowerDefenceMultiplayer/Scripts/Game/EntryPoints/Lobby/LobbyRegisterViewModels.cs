using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class LobbyRegisterViewModels
    {
        public static void RegisterServerViewModels(DIContainer container, LobbyEnterParams lobbyEnterParams)
        {
            container.RegisterSingleton<IMapViewModel>(factory => new MapViewModel(
                factory.Resolve<IGameStateProvider>(), factory.Resolve<IEntityViewModelFactoryService>()));
            
            container.RegisterSingleton<IWorldRootViewModel>(factory => new WorldRootViewModel(factory.Resolve<IMapViewModel>()));
            
            //After register
            var mapViewModel = container.Resolve<IMapViewModel>();
            mapViewModel.AttachEntityHasherService(container.Resolve<IPlayerService>());
        }

        public static void RegisterClientViewModels(DIContainer container, LobbyEnterParams lobbyEnterParams)
        {
            container.RegisterSingleton<IPlayerClientViewModel>(factory => new PlayerClientViewModel(factory.Resolve<IGameInputProvider>().GetPlayerInputs(), factory.Resolve<IPlayerClientService>()));
        }
    }
}