using SkyForge.Reactive;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerModel : IEntityStateModel<PlayerData>
    {
        ulong ClientId { get; }
        ReactiveProperty<float> HealthPoint { get; }
    }
}