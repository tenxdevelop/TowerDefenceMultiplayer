using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class MapViewModel : ViewModel, IMapViewModel
    {
        public ReactiveCollection<IPlayerServerViewModel> Players { get; private set; }

        public MapViewModel(IPlayerService playerService)
        {
            Players = playerService.Players;
        }
    }
}