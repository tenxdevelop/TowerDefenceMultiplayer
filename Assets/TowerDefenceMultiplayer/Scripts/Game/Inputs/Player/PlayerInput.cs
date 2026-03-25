using SkyForge.Input;
using UnityEngine;
using System;

namespace TowerDefenceMultiplayer
{
    public class PlayerInput : BaseInput, IPlayerInput
    {
        public event Action<Vector2> PlayerMovedEvent;
        
        public PlayerInput(IInputMapper inputMapper) : base(inputMapper)
        {
            var playerInputMapper = inputMapper.As<GameInputMapper>() as IPlayerInputMapper;
            playerInputMapper.PlayerMovedEvent += OnPlayerMoved;
        }

        public void Dispose()
        {
            var playerInputMapper = InputMapper.As<GameInputMapper>() as IPlayerInputMapper;
            playerInputMapper.PlayerMovedEvent -= OnPlayerMoved;
        }

        private void OnPlayerMoved(Vector2 direction)
        {
            PlayerMovedEvent?.Invoke(direction);
        }
    }
}