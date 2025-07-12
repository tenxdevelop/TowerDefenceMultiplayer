using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class UIRootMainMenuViewModel : IUIRootMainMenuViewModel
    {

        private ApplicationService _applicationService;

        public UIRootMainMenuViewModel(ApplicationService applicationService)
        {
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
