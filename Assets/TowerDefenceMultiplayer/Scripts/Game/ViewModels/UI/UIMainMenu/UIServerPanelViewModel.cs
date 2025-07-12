using SkyForge.Reactive;
using SkyForge.MVVM;
using System;

namespace TowerDefenceMultiplayer
{
    public class UIServerPanelViewModel : IUIServerPanelViewModel
    {
        public event Action OnCreatedLobbyEvent;
        public ReactiveProperty<bool> IsActiveMenu { get; } = new();
        
        private SingleReactiveProperty<MainMenuExitParams> _mainMenuExitParams;
        
        public UIServerPanelViewModel(SingleReactiveProperty<MainMenuExitParams> mainMenuExitParams)
        {
            _mainMenuExitParams = mainMenuExitParams;
        }
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
           
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
        
        [ReactiveMethod]
        public void CreateLobby(object sender)
        {
            OnCreatedLobbyEvent?.Invoke();
            HideMenu();
        }
        
        [ReactiveMethod]
        public void JoinLobby(object sender)
        {

        }
        
        [ReactiveMethod]
        public void Connection(object sender)
        {
            
        }

        public void ShowMenu()
        {
            IsActiveMenu.Value = true;
        }

        public void HideMenu()
        {
            IsActiveMenu.Value = false;
        }
    }
}