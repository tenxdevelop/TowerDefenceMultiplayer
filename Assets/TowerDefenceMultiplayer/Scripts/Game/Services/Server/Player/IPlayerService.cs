using SkyForge.Reactive;
using UnityEngine;
using System;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerService : IDisposable, IEntityViewModelHasherService
    {
        bool CreatePlayer(ulong clientId, string configId, Vector3 position);
        void RegisterNetworkMessageHandlers();
        void MovePlayer(int entityId, Vector2 direction, float deltaTime);
    }
}