using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class MainMenuRegisterViewModels
    {
        public static void RegisterViewModels(DIContainer container, MainMenuEnterParams mainMenuEnterParams)
        {
            container.RegisterSingleton<IUIServerPanelViewModel>(factory => new UIServerPanelViewModel());
            
            container.RegisterSingleton<IUICreateLobbyMenuViewModel>(factory => new UICreateLobbyMenuViewModel(factory.Resolve<MenuNetworkService>()));
            
            container.RegisterSingleton<IUIJoinLobbyMenuViewModel>(factory => new UIJoinLobbyMenuViewModel(factory.Resolve<MenuNetworkService>()));
            
            container.RegisterSingleton<IUIRootMainMenuViewModel>(factory => new UIRootMainMenuViewModel(factory.Resolve<ApplicationService>(), 
                factory.Resolve<IUIServerPanelViewModel>(),factory.Resolve<IUICreateLobbyMenuViewModel>(), 
                factory.Resolve<IUIJoinLobbyMenuViewModel>()));
            
        }
    }
}