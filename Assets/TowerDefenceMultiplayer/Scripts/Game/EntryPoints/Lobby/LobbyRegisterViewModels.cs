using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class LobbyRegisterViewModels
    {
        public static void RegisterServerViewModels(DIContainer container, LobbyEnterParams lobbyEnterParams)
        {
            container.RegisterSingleton<IMapViewModel>(factory => new MapViewModel(factory.Resolve<IPlayerService>()));
            container.RegisterSingleton<IWorldRootViewModel>(factory => new WorldRootViewModel(factory.Resolve<IMapViewModel>()));
        }

        public static void RegisterClientViewModels(DIContainer container, LobbyEnterParams lobbyEnterParams)
        {
            container.RegisterSingleton<IPlayerClientViewModel>(factory => new PlayerClientViewModel());
        }
    }
}