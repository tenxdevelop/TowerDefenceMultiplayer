using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class UIRootMainMenuViewModel : IUIRootMainMenuViewModel
    {
        [SubViewModel(typeof(UIServerPanelViewModel))]
        public IUIServerPanelViewModel UIServerPanelViewModel { get; private set; }
        
        [SubViewModel(typeof(UICreateLobbyMenuViewModel))]
        public IUICreateLobbyMenuViewModel UICreateLobbyMenuViewModel { get; private set; }
        
        private ApplicationService _applicationService;

        public UIRootMainMenuViewModel(ApplicationService applicationService,  IUIServerPanelViewModel uIServerPanelViewModel, IUICreateLobbyMenuViewModel uICreateLobbyMenuViewModel)
        {
            UIServerPanelViewModel = uIServerPanelViewModel;
            UIServerPanelViewModel.OnCreatedLobbyEvent += OnCreatedLobbyCallback;
            
            UICreateLobbyMenuViewModel = uICreateLobbyMenuViewModel;
            
            _applicationService =  applicationService;
        }
        
        public void Dispose()
        {
            UIServerPanelViewModel.OnCreatedLobbyEvent -= OnCreatedLobbyCallback;
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
            if (!UICreateLobbyMenuViewModel.IsActiveMenu.Value)
            {
                UIServerPanelViewModel.ShowMenu();
            }
        }

        private void OnCreatedLobbyCallback()
        {
            UICreateLobbyMenuViewModel.ShowMenu();
        }
    }
}
