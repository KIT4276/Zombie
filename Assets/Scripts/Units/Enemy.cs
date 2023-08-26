using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : BaseUnit
{
    [Inject]
    private Player _player;

    private EnemiesAI _ai;
    protected EnemyParams _enemyParams;

    [SerializeField]
    private HealthBar _healthBar;

    

    protected override void Start()
    {
        base.Start();
        _enemyParams = GetComponent<EnemyParams>();

        _ai = new EnemiesAI();
        Debug.Log(_player);
        _ai.Initialized
            (this, _enemyParams.GetVewAngle(), _enemyParams.GetViewlDistance(), _enemyParams.GetDetectionDistance(),
            _enemyParams.GetEye(), _enemyParams.GetMoveSpeed(), _enemyParams.GetRotationSpeed(), _player.transform);
        _healthBar.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");
        if (other.GetComponent<BatTrigger>() && other.GetComponentInParent<Player>().GetIsAttack())
        {
           // Debug.Log("BatTrigger");

            TakeDamage(_player.GetParams().GetAttackValue());
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
}
