using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class UICreateLobbyMenuViewModel : MenuViewModel, IUICreateLobbyMenuViewModel
    {
        
        private SingleReactiveProperty<MainMenuExitParams> _mainMenuExitParams;
        
        private string _lobbyCode;
        private string _serverName;
        private string _country;
        private int _countPlayer;
        
        public UICreateLobbyMenuViewModel(SingleReactiveProperty<MainMenuExitParams> mainMenuExitParams)
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
            _lobbyCode = lobbyCode;
        }

        [ReactiveMethod]
        public void SetServerName(object sender, string serverName)
        {
            _serverName = serverName;
        }

        [ReactiveMethod]
        public void SetCountPlayer(object sender, int countPlayer)
        {
            _countPlayer = countPlayer;
        }
        
        [ReactiveMethod]
        public void SetCountry(object sender, string country)
        {
            _country = country;
        }

        [ReactiveMethod]
        public void CreateLobby(object sender)
        {
            var lobbyEnterParams = new LobbyEnterParams(_lobbyCode, _serverName, _country, _countPlayer, true);
            
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