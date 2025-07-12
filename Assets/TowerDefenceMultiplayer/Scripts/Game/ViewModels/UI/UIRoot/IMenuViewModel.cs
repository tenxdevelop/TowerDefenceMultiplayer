using SkyForge.MVVM;
using SkyForge.Reactive;

namespace TowerDefenceMultiplayer
{
    public interface IMenuViewModel : IViewModel
    {
        ReactiveProperty<bool> IsActiveMenu { get; }
        
        void ShowMenu();

        void HideMenu();
    }
}