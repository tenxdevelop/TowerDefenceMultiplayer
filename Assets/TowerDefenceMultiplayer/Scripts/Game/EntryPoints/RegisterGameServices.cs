using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class RegisterGameServices
    {
        public static void RegisterServices(DIContainer container)
        {
            container.RegisterSingleton<SceneService>(factory => new SceneService());
            container.RegisterSingleton<LoadService>(factory => new LoadService());
            container.RegisterSingleton<ApplicationService>(factory => new ApplicationService());
            
            container.RegisterSingleton<IEntityFactoryService>(factory => new EntityFactoryService());
            container.RegisterSingleton<IGameStateProvider>(factory => new PlayerPrefsGameStateProvider(factory.Resolve<IEntityFactoryService>()));
            
        }
    }
}
