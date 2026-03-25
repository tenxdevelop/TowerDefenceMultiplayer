using SkyForge.Reactive;
using UnityEngine;
using System;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerService : IDisposable
    {
        ReactiveCollection<IPlayerServerViewModel> Players { get; }
        bool CreatePlayer(ulong clientId, string configId, Vector3 position);
        void RegisterNetworkMessageHandlers();
    }
}