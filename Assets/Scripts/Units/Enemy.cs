using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : BaseUnit
{
    [Inject]
    private readonly Player _player;

    private EnemiesAI _ai;
    private EnemyParams _enemyParams;
    private Move _move;

    [SerializeField]
    private HealthBar _healthBar;
    

    protected override void Start()
    {
        base.Start();
        _move = new Move();
        _enemyParams = GetComponent<EnemyParams>();
        _move.Initialized(_params.GetMoveSpeed(), this.gameObject);

        _ai = new EnemiesAI();
        _ai.Initialized
            (this, _enemyParams.GetVewAngle(), _enemyParams.GetViewlDistance(), _enemyParams.GetDetectionDistance(),_enemyParams.GetEye(),
            _enemyParams.GetMoveSpeed(), _enemyParams.GetRotationSpeed(), _player.transform, _enemyParams.GetStoppingDistance());
        _healthBar.Init();

        _ai.EnemyAttackE += EnemyAttack;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BatTrigger>() && other.GetComponentInParent<Player>().GetIsAttack())
        {
            TakeDamage(_player.GetParams().GetAttackValue());
            _ai.SetTarget(true);
        }
    }

    private void FixedUpdate()
    {
        if (IsAlive)
        {
            _ai.UpdateAI();
        }

        if (_ai.IsMoving)
        {
            _animation.MoveAnimStart();
        }
        else
        {
            _animation.MoveAnimStop();
        }
    }

    protected override void Death()
    {
        base.Death();
        _healthBar.gameObject.SetActive(false);
    }

    private void EnemyAttack()
    {
        if(! _attack.IsAttack && _ai.IsDetected && _player.IsAlive)
            UnitAttack();
    }

    private void OnDestroy()
    {
        _ai.EnemyAttackE -= EnemyAttack;
    }
}
