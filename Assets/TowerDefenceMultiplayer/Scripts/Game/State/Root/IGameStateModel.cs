using SkyForge.Reactive;
using SkyForge.Proxy;

namespace TowerDefenceMultiplayer
{
    public interface IGameStateModel : IProxy<GameStateData>
    {
        ReactiveCollection<IEntityStateModel> Entities { get; }

        int GetEntityId();
    }
}