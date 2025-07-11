using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IUIRootMainMenuViewModel : IViewModel
    {
        void ExitGame(object sender);

        void Play(object sender);
    }
}