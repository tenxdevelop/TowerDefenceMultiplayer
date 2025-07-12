using System;

namespace TowerDefenceMultiplayer
{
    public interface IUIServerPanelViewModel : IMenuViewModel
    {
        event Action OnCreatedLobbyEvent;
        event Action OnJoinedLobbyEvent;
        void CreateLobby(object sender);
        
        void JoinLobby(object sender);
        
        void Connection(object sender);
        
    }
}