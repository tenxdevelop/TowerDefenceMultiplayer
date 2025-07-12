using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IUICreateLobbyMenuViewModel : IViewModel
    {
        ReactiveProperty<bool> IsActiveMenu { get; }
        void SetLobbyCode(object sender, string lobbyCode);
        
        void SetServerName(object sender, string serverName);
        
        void SetCountry(object sender, string country);
        
        void SetCountPlayer(object sender, int countPlayer);
        void CreateLobby(object sender);
        void ShowMenu();
        void HideMenu();
        void Cancel(object sender);
    }
}