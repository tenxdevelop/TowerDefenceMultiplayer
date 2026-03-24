using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class WorldRootViewModel : ViewModel, IWorldRootViewModel
    {
        [SubViewModel(typeof(MapViewModel))]
        public IMapViewModel MapViewModel { get; private set; }
        
        public WorldRootViewModel(IMapViewModel mapViewModel)
        {
            MapViewModel = mapViewModel;
        }
    }
}