using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IMapViewModel : IViewModel
    {
        ReactiveCollection<IPlayerServerViewModel> Players { get; }
    }
}