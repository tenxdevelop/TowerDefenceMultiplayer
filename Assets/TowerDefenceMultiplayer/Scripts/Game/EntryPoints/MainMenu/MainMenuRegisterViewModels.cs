using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class MainMenuRegisterViewModels
    {
        public static void RegisterViewModels(DIContainer container, MainMenuEnterParams mainMenuEnterParams)
        {
            container.RegisterSingleton<IUIRootMainMenuViewModel>(factory => new UIRootMainMenuViewModel(factory.Resolve<ApplicationService>(), 
                factory.Resolve<IUIServerPanelViewModel>(),factory.Resolve<IUICreateLobbyMenuViewModel>(), 
                factory.Resolve<IUIJoinLobbyMenuViewModel>()));
            
        }
    }
}