using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IEntityViewModel : INetworkViewModel
    {
        EntityType EntityType { get; }
    }
}