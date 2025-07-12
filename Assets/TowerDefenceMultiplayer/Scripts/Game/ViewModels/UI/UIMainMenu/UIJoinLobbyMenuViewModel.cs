using SkyForge.MVVM;
using SkyForge.Reactive;

namespace TowerDefenceMultiplayer
{
    public class UIJoinLobbyMenuViewModel : MenuViewModel, IUIJoinLobbyMenuViewModel
    {
        
        private SingleReactiveProperty<MainMenuExitParams> _mainMenuExitParams;

        private string _lobbyCode;
        
        public UIJoinLobbyMenuViewModel(SingleReactiveProperty<MainMenuExitParams> mainMenuExitParams)
        {
            _mainMenuExitParams = mainMenuExitParams;
        }
        
        public override void Dispose()
        {
            
        }

        public override void Update(float deltaTime)
        {
            
        }

        public override void PhysicsUpdate(float deltaTime)
        {
            
        }
        
        [ReactiveMethod]
        public void SetLobbyCode(object sender, string lobbyCode)
        {
            
        }
    
        [ReactiveMethod]
        public void JoinLobby(object sender)
        {
            var lobbyEnterParams = new LobbyEnterParams(_lobbyCode, "", "", 0, false);
            
            HideMenu();
            
            _mainMenuExitParams.Value = new MainMenuExitParams(lobbyEnterParams);
        }
        
        [ReactiveMethod]
        public void Cancel(object sender)
        {
            _lobbyCode = string.Empty;
            
            HideMenu();
        }
    }
}