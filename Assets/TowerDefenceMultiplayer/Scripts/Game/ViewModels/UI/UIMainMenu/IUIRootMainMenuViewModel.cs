using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IUIRootMainMenuViewModel : IViewModel
    {
        IUIServerPanelViewModel UIServerPanelViewModel { get; }
        IUICreateLobbyMenuViewModel UICreateLobbyMenuViewModel { get; }
        void ExitGame(object sender);
        void Play(object sender);
    }
}