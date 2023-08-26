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
    protected EnemyParams _enemyParams;

    [SerializeField]
    private HealthBar _healthBar;
    

    protected override void Start()
    {
        base.Start();
        _enemyParams = GetComponent<EnemyParams>();

        _ai = new EnemiesAI();
        _ai.Initialized
            (this, _enemyParams.GetVewAngle(), _enemyParams.GetViewlDistance(), _enemyParams.GetDetectionDistance(),_enemyParams.GetEye(),
            _enemyParams.GetMoveSpeed(), _enemyParams.GetRotationSpeed(), _player.transform, _enemyParams.GetStoppingDistance());
        _healthBar.Init();

        _ai.AttackE += EnemyAttack;
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
}
