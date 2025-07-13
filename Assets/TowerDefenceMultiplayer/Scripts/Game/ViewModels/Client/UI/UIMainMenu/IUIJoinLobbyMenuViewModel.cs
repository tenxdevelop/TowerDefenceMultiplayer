using SkyForge.Extension;

namespace TowerDefenceMultiplayer
{
    public interface IUIJoinLobbyMenuViewModel : IUIMenuPanelViewModel
    {
        void SetLobbyCode(object sender, string lobbyCode);
        
        void JoinLobby(object sender);
        
        void Cancel(object sender);
        
        
    }
}