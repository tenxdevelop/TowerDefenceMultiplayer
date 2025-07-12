using SkyForge.Reactive;

namespace TowerDefenceMultiplayer
{
    public class UIRootViewModel : IUIRootViewModel
    {
        public ReactiveProperty<bool> IsLoading { get; private set; } = new();

        public ReactiveCollection<UIScreenView> StaticScreens { get; private set; } = new();

        public ReactiveCollection<UIScreenView> Screens { get; private set; } = new();
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }

        public void ShowLoadingScreen()
        {
            IsLoading.Value = true;
        }
        
        public void HideLoadingScreen()
        {
            IsLoading.Value = false;
        }

        public void AttachStaticScreenView(UIScreenView screenView)
        {
            StaticScreens.Add(screenView);
        }

        public void AttachScreenView(UIScreenView screenView)
        {
            Screens.Add(screenView);
        }

        public void ClearStaticScreens()
        {
            StaticScreens.Clear();
        }

        public void ClearScreens()
        {
            Screens.Clear();
        }
    }
}