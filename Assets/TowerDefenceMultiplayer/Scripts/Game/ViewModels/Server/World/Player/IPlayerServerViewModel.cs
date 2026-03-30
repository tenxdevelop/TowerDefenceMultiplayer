using SkyForge.Reactive;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerServerViewModel : IEntityViewModel
    {
        ReactiveProperty<Vector3> Position { get; }

        void UpdateMoveDirection(Vector2 direction);
    }
}