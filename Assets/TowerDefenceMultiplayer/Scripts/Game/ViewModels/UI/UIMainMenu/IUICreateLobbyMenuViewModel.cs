using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IUICreateLobbyMenuViewModel : IMenuViewModel
    {
        void SetLobbyCode(object sender, string lobbyCode);
        
        void SetServerName(object sender, string serverName);
        
        void SetCountry(object sender, string country);
        
        void SetCountPlayer(object sender, int countPlayer);
        void CreateLobby(object sender);
        void Cancel(object sender);
    }
}