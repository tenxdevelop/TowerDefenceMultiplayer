using SkyForge.Reactive;
using SkyForge.MVVM;
using System;

namespace TowerDefenceMultiplayer
{
    public interface IUIServerPanelViewModel : IViewModel
    {
        event Action OnCreatedLobbyEvent;
        ReactiveProperty<bool> IsActiveMenu { get; }
        void CreateLobby(object sender);
        
        void JoinLobby(object sender);
        
        void Connection(object sender);

        void ShowMenu();

        void HideMenu();
    }
}