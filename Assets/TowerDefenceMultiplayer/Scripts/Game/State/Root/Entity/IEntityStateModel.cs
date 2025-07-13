using SkyForge.Reactive;
using SkyForge.Proxy;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public interface IEntityStateModel<EntityState> : IEntityStateModel, IProxy<EntityState> where EntityState : EntityStateData
    {
        
    }

    public interface IEntityStateModel
    {
        ReactiveProperty<Vector3> Position { get; }
        EntityType EntityType { get; }
        int UniqueId { get; }
        string ConfigId { get; }
    }
}