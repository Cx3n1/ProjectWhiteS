
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpiderBrain : SpiderBrain
{
    
    private PlayerInputActions _playerInputActions;

    public void Start()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Jump.performed += OnJump;
        //_playerInputActions.Player.Movement.performed += OnMovement;
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        InvokeMovement(context.ReadValue<Vector2>());
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        InvokeJump();
    }

    public override Vector2 GetMovement()
    {
        return _playerInputActions.Player.Movement.ReadValue<Vector2>();
    }
}
