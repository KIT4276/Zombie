using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput
{
    private PlayerControls _controls;
    public Vector3 DirectionToWalk { get; private set; }

    public event Action PlayerAttackE;

    public void Initialized()
    {
        _controls = new PlayerControls();
        _controls.OnFootActionMap.Enable();
        _controls.OnFootActionMap.Attack.performed += Attack;
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        PlayerAttackE?.Invoke();
    }

    public void UpdateMove()
    {
        DirectionToWalk = new Vector3
            (_controls.OnFootActionMap.Move.ReadValue<Vector2>().x, 0f, _controls.OnFootActionMap.Move.ReadValue<Vector2>().y);
    }

    public Vector3 GetDirection() => DirectionToWalk;

    public void OnDeath()
    {
        _controls.OnFootActionMap.Disable();
        _controls.OnFootActionMap.Attack.performed -= Attack;
    }
}
