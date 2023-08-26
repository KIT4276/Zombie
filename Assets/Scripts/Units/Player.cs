using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : BaseUnit
{
    private PlayerInput _playerInput;
    
    protected override void Start()
    {
        base.Start();
        
        _playerInput = new PlayerInput();
        _playerInput.Initialized();
        _playerInput.AttackE += UnitAttack;
    }

    private void Update()
    {
        if (IsAlive)
        {
            _playerInput.UpdateMove();
            _move.OnMove(_playerInput.GetDirection());
            _move.OnRotate();

            if (_playerInput.DirectionToWalk == Vector3.zero)
            {
                _animation.MoveAnimStop();
            }
            else
            {
                _animation.MoveAnimStart();
            }
        }
    }

    protected override void Death()
    {
        base.Death();
    }
}
