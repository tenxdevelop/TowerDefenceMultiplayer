using SkyForge.Reactive;

namespace TowerDefenceMultiplayer
{
    public abstract class MenuViewModel : IMenuViewModel
    {
        public ReactiveProperty<bool> IsActiveMenu { get; } = new();
        
        public abstract void Dispose();
        
        public abstract void Update(float deltaTime);
        
        public abstract void PhysicsUpdate(float deltaTime);

        public void HideMenu()
        {
            IsActiveMenu.Value = false;
        }

        public void ShowMenu()
        {
            IsActiveMenu.Value = true;
        }
    }
}