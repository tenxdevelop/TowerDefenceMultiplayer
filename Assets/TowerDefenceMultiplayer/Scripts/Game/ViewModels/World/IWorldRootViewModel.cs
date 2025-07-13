using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IWorldRootViewModel : IViewModel
    {
        IMapViewModel MapViewModel { get; }
    }
}