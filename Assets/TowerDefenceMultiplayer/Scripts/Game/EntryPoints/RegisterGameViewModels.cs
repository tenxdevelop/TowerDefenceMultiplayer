using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class RegisterGameViewModels
    {
        public static void RegisterViewModels(DIContainer container)
        {
            container.RegisterSingleton<IUIRootViewModel>(factory => new UIRootViewModel());
        }
    }
}