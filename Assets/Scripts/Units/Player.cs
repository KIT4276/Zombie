using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : BaseUnit
{
    private PlayerInput _playerInput;
    private PlayerMove _move;

    [SerializeField]
    private GameObject _backpack;

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

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.TryGetComponent<AddressTrigger>(out var adresTrigger))
        {
            adresTrigger.AdresTriggerEnter();
            _backpack.SetActive(false);
        }
        else if(other.TryGetComponent<PostTrigger>(out var postTrigger))
        {
            postTrigger.PostTriggerEnter();
            _backpack.SetActive(true);
        }
        else if (other.TryGetComponent<AIDTrigger>(out var aid))
        {
            _health.CangeHealth( aid.AIDTriggerEnter());
            //todo Despawn
            other.gameObject.SetActive(false);
        }
    }


    protected override void Death()
    {
        _playerInput.OnDeath();
        base.Death();
    }
}
