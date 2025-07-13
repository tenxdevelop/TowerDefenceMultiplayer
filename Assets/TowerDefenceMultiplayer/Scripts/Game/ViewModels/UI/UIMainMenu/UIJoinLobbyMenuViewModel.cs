using SkyForge.Extension;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class UIJoinLobbyMenuViewModel : UIMenuPanelViewModel, IUIJoinLobbyMenuViewModel
    {
        
        private MenuNetworkService _menuNetworkService;

        private string _lobbyCode;
        
        public UIJoinLobbyMenuViewModel(MenuNetworkService menuNetworkService)
        {
            _menuNetworkService = menuNetworkService;
        }
        
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
        public void SetLobbyCode(object sender, string lobbyCode)
        {
            
        }
    
        [ReactiveMethod]
        public void JoinLobby(object sender)
        {
            HideMenu();
            _menuNetworkService.JoinLobby(_lobbyCode);
        }
        
        [ReactiveMethod]
        public void Cancel(object sender)
        {
            _lobbyCode = string.Empty;
            
            HideMenu();
        }
    }
}