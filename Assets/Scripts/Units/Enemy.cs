using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : BaseUnit
{
    private EnemiesAI _ai;

    [SerializeField]
    private HealthBar _healthBar;

    [Inject]
    private Player _player;

    protected override void Start()
    {
        base.Start();
        _ai = new EnemiesAI();
        _ai.Initialized(this);
        _healthBar.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.TryGetComponent<BatTrigger>(out var bat))
        {
            Debug.Log("BatTrigger");
            TakeDamage(_player.GetParams().GetAttackValue());
        }
    }
}
