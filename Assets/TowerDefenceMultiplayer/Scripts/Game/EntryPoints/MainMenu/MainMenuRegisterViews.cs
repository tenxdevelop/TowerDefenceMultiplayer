using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class MainMenuRegisterViews
    {
        public static void RegisterViews(DIContainer container)
        {
            var loadService = container.Resolve<LoadService>();
            
            // Load staticUIRootMainMenu
            var prefabStaticUIRootMainMenuView = loadService.LoadPrefab<StaticUIRootMainMenuView>(LoadService.PREFAB_UI_STATIC_UIROOT_MAIN_MENU);
            var staticUIRootMainMenuView = loadService.CreateGameObject(prefabStaticUIRootMainMenuView);
            
            // Load UIRootMainMenu
            var prefabUIRootMainMenuView = loadService.LoadPrefab<UIRootMainMenuView>(LoadService.PREFAB_UI_UIROOT_MAIN_MENU);
            var uIRootMainMenuViewModel = container.Resolve<IUIRootMainMenuViewModel>();
            var uIRootMainMenuView = loadService.CreateView(prefabUIRootMainMenuView, uIRootMainMenuViewModel);
            
            // Added UI View to root container
            var uIRootViewModel = container.Resolve<IUIRootViewModel>();
            
            uIRootViewModel.AttachScreenView(uIRootMainMenuView);
            uIRootViewModel.AttachStaticScreenView(staticUIRootMainMenuView);
            
        }
    }
}