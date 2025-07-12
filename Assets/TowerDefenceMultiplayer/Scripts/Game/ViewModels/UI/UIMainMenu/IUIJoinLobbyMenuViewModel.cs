
namespace TowerDefenceMultiplayer
{
    public interface IUIJoinLobbyMenuViewModel : IMenuViewModel
    {
        void SetLobbyCode(object sender, string lobbyCode);
        
        void JoinLobby(object sender);
        
        void Cancel(object sender);
        
        
    }
}