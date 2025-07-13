using SkyForge.Reactive;
using UnityEngine;
using System;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerService : IDisposable
    {
        ReactiveCollection<IPlayerViewModel> Players { get; }
        public bool CreatePlayer(ulong clientId, string configId, Vector3 position);
    }
}