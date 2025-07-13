using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerViewModel : INetworkViewModel
    {
        ReactiveProperty<Vector3> Position { get; }
    }
}