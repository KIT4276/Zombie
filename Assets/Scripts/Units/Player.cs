using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class Player : BaseUnit
{
    private PlayerInput _playerInput;
    private PlayerMove _move;


    protected override void Start()
    {
        base.Start();

        _move = new PlayerMove(GetComponent<CharacterController>());
        _playerInput = new PlayerInput();
        _playerInput.Initialized();
        _move.Initialized(_params.GetMoveSpeed(), this.gameObject);
        _playerInput.PlayerAttackE += UnitAttack;
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent <BatTrigger>(out var bat) && other.TryGetComponent<Enemy>(out var enemy) && enemy.GetIsAttack())
    //    {
    //        TakeDamage(other.GetComponentInParent<Enemy>().GetParams().GetAttackValue());
    //    }
    //}

    protected override void Death()
    {
        _playerInput.OnDeath();
        base.Death();
    }

    
}
