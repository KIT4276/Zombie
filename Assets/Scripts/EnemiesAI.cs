using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemiesAI 
{
    private NavMeshAgent _navMeshAgent;

    [Inject]
    private Player _player;

    public void Initialized(Enemy enemy)
    {
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
    }
}
