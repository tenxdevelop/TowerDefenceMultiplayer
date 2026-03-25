
using SkyForge.Input;
using UnityEngine;
using System;

namespace TowerDefenceMultiplayer
{
    public interface IPlayerInput : IInput
    {
        event Action<Vector2> PlayerMovedEvent;
    }
}