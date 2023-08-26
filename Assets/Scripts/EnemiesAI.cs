using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesAI 
{
    private NavMeshAgent _navMeshAgent;

    public void Initialized(Enemy enemy)
    {
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
    }
}
