using SkyForge.Reactive;

namespace TowerDefenceMultiplayer
{
    public class MapViewModel : IMapViewModel
    {
        public ReactiveCollection<IPlayerServerViewModel> Players { get; private set; }

        public MapViewModel(IPlayerService playerService)
        {
            Players = playerService.Players;
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