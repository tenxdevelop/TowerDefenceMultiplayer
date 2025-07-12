using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IUIServerPanelViewModel : IViewModel
    {

        ReactiveProperty<string> LobbyCode { get; }
        void CreateLobby(object sender);
        
        void JoinLobby(object sender);
        
        void Connection(object sender);
    }
}