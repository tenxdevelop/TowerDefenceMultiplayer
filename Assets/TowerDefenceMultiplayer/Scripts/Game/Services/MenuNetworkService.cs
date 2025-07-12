using SkyForge.Reactive;
using System;

namespace TowerDefenceMultiplayer
{
    public class MenuNetworkService : IDisposable
    {
        public SingleReactiveProperty<MainMenuExitParams> _mainMenuExitParams;

        public MenuNetworkService(SingleReactiveProperty<MainMenuExitParams> mainMenuExitParams)
        {
            _mainMenuExitParams = mainMenuExitParams;
        }
        
        public void CreateLobby(string lobbyCode, string lobbyName, string country, int countPeople)
        {
            var lobbyEnterParams = new LobbyEnterParams(lobbyCode, lobbyName, country, countPeople, true);
            _mainMenuExitParams.Value = new MainMenuExitParams(lobbyEnterParams);
        }

        public void JoinLobby(string lobbyCode)
        {
            var lobbyEnterParams = new LobbyEnterParams(lobbyCode, "", "", 0, false);
            _mainMenuExitParams.Value = new MainMenuExitParams(lobbyEnterParams);
        }
        
        public void Dispose()
        {
            
        }
    }
}
