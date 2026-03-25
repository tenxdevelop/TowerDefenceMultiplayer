using UnityEngine;
using System;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerInputMapper
    {
        event Action<Vector2> PlayerMovedEvent;
    }
}