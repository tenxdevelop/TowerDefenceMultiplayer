using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IUIRootViewModel : IViewModel
    {
        ReactiveProperty<bool> IsLoading { get; }
        
        ReactiveCollection<UIScreenView> StaticScreens { get; }
        ReactiveCollection<UIScreenView> Screens { get; }
        
        void ShowLoadingScreen();

        void AttachStaticScreenView(UIScreenView screenView);

        void AttachScreenView(UIScreenView screenView);

        void DetachStaticScreenView(UIScreenView screenView);

        void DetachScreenView(UIScreenView screenView);
        
        void HideLoadingScreen();
    }
}
