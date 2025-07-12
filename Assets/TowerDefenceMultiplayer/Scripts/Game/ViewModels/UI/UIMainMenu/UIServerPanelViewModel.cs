using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class UIServerPanelViewModel : IUIServerPanelViewModel
    {
        public ReactiveProperty<string> LobbyCode { get; private set; } = new();
        
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
            
        }
        
        [ReactiveMethod]
        public void JoinLobby(object sender)
        {
            Debug.Log("lobby code: " + LobbyCode.Value);
        }
        
        [ReactiveMethod]
        public void Connection(object sender)
        {
            
        }
    }
}