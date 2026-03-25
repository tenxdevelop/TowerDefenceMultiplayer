using UnityEngine.InputSystem;
using SkyForge.Input;
using UnityEngine;
using System;

namespace TowerDefenceMultiplayer
{
    public class GameInputMapper : BaseInputMapper<GameNewInputSystem>, IPlayerInputMapper
    {
        public event Action<Vector2> PlayerMovedEvent;

        public GameInputMapper()
        {
            OriginInput.PlayerInput.Move.performed += OnPlayerInputMovePerformed;
            OriginInput.PlayerInput.Move.canceled += OnPlayerInputMovePerformed;
        }
        
        public override void Dispose()
        {
            OriginInput.PlayerInput.Move.performed -= OnPlayerInputMovePerformed;
            OriginInput.PlayerInput.Move.canceled -= OnPlayerInputMovePerformed;
        }

        private void OnPlayerInputMovePerformed(InputAction.CallbackContext context)
        {  
            PlayerMovedEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }
}