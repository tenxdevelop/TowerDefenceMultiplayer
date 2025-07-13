using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class LobbyRegisterViews
    {
        public static void RegisterServerViews(DIContainer container)
        {
            var loadService = container.Resolve<LoadService>();

            var prefabWorldView = loadService.LoadPrefab<WorldRootView>(LoadService.PREFAB_WORLD_WORLDROOT);
            var worldRootViewModel = container.Resolve<IWorldRootViewModel>();
            
            loadService.CreateView(prefabWorldView, worldRootViewModel);
        }

        public static void RegisterClientViews(DIContainer container)
        {
            
        }
    }
}