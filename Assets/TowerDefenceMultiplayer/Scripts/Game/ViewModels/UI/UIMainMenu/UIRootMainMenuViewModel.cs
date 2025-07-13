using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class UIRootMainMenuViewModel : IUIRootMainMenuViewModel
    {
        [SubViewModel(typeof(UIServerPanelViewModel))]
        public IUIServerPanelViewModel UIServerPanelViewModel { get; private set; }
        
        [SubViewModel(typeof(UICreateLobbyMenuViewModel))]
        public IUICreateLobbyMenuViewModel UICreateLobbyMenuViewModel { get; private set; }
        
        [SubViewModel(typeof(UIJoinLobbyMenuViewModel))]
        public IUIJoinLobbyMenuViewModel UIJoinLobbyMenuViewModel { get; private set; }
        
        private ApplicationService _applicationService;

        public UIRootMainMenuViewModel(ApplicationService applicationService,  IUIServerPanelViewModel uIServerPanelViewModel, IUICreateLobbyMenuViewModel uICreateLobbyMenuViewModel,
            IUIJoinLobbyMenuViewModel uIJoinLobbyMenuViewModel)
        {
            UIServerPanelViewModel = uIServerPanelViewModel;
            UIServerPanelViewModel.OnCreatedLobbyEvent += OnCreatedLobbyCallback;
            UIServerPanelViewModel.OnJoinedLobbyEvent += OnJoinedLobbyCallback;
            
            UICreateLobbyMenuViewModel = uICreateLobbyMenuViewModel;
            UIJoinLobbyMenuViewModel = uIJoinLobbyMenuViewModel;
            
            _applicationService =  applicationService;
        }
        
        public void Dispose()
        {
            UIServerPanelViewModel.OnCreatedLobbyEvent -= OnCreatedLobbyCallback;
            UIServerPanelViewModel.OnJoinedLobbyEvent -= OnJoinedLobbyCallback;
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
            if (!UICreateLobbyMenuViewModel.IsActive.Value)
            {
                UIServerPanelViewModel.ShowMenu();
            }
        }

        private void OnCreatedLobbyCallback()
        {
            UICreateLobbyMenuViewModel.ShowMenu();
        }

        private void OnJoinedLobbyCallback()
        {
            UIJoinLobbyMenuViewModel.ShowMenu();
        }
    }
}
