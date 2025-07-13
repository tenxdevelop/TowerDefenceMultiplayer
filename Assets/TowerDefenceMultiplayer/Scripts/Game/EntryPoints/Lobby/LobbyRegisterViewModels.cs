using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class LobbyRegisterViewModels
    {
        public static void RegisterViewModels(DIContainer container, LobbyEnterParams lobbyEnterParams)
        {
            container.RegisterSingleton<IMapViewModel>(factory => new MapViewModel(factory.Resolve<IPlayerService>()));
            container.RegisterSingleton<IWorldRootViewModel>(factory => new WorldRootViewModel(factory.Resolve<IMapViewModel>()));
        }
    }
}