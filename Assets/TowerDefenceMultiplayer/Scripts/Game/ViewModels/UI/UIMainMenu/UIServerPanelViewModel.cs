using SkyForge.Reactive;
using SkyForge.MVVM;
using System;

namespace TowerDefenceMultiplayer
{
    public class UIServerPanelViewModel : MenuViewModel, IUIServerPanelViewModel
    {
        public event Action OnCreatedLobbyEvent;
        public event Action OnJoinedLobbyEvent;
        
        public override void Dispose()
        {
            
        }

        public override void Update(float deltaTime)
        {
           
        }

        public override void PhysicsUpdate(float deltaTime)
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
            OnJoinedLobbyEvent?.Invoke();
            HideMenu();
        }
        
        [ReactiveMethod]
        public void Connection(object sender)
        {
            
        }
    }
}