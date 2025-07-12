using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class UIRootMainMenuViewModel : IUIRootMainMenuViewModel
    {
        [SubViewModel(typeof(UIServerPanelViewModel))]
        public IUIServerPanelViewModel UIServerPanelViewModel { get; private set; }
        
        private ApplicationService _applicationService;

        public UIRootMainMenuViewModel(ApplicationService applicationService,  IUIServerPanelViewModel uIServerPanelViewModel)
        {
            UIServerPanelViewModel = uIServerPanelViewModel;
            
            _applicationService =  applicationService;
        }
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
        
        [ReactiveMethod]
        public void ExitGame(object sender)
        {
            _applicationService.CloseGame();
        }
        
        [ReactiveMethod]
        public void Play(object sender)
        {
            
        }
    }
}
