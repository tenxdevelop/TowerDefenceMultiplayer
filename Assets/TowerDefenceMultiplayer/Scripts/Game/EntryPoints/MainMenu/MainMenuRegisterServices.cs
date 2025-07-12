using SkyForge.Reactive;
using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class MainMenuRegisterServices
    {
        public static void RegisterServices(DIContainer container, MainMenuEnterParams mainMenuEnterParams, SingleReactiveProperty<MainMenuExitParams> mainMenuExitParams)
        {
            container.RegisterSingleton<MenuNetworkService>(factory => new MenuNetworkService(mainMenuExitParams));
        }
    }
}