using System;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerClientService : IDisposable
    {
        void UpdatePlayerMoveDirection(ulong clientId, Vector2 direction);
    }
}