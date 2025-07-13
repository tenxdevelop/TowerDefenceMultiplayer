using SkyForge.Reactive;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerModel : IEntityStateModel<PlayerData>
    {
        ReactiveProperty<float> HealthPoint { get; }
    }
}