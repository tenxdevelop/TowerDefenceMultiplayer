using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public class WorldRootViewModel : IWorldRootViewModel
    {
        [SubViewModel(typeof(MapViewModel))]
        public IMapViewModel MapViewModel { get; private set; }
        
        
        public WorldRootViewModel(IMapViewModel mapViewModel)
        {
            MapViewModel = mapViewModel;
        }
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
    }
}