using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerServerViewModel : INetworkViewModel
    {
        ReactiveProperty<Vector3> Position { get; }
    }
}