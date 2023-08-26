using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemiesAI 
{
    //[Inject]
    //private Player _player;

    private NavMeshAgent _navMeshAgent;

    private float _viewAngle;
    private float _viewlDistance;
    private float _detectionDistance;
    private Transform _eye;

    private Transform _target;

    private Vector3 _startPos;

    public bool IsMoving { get; private set; }

    public void Initialized(Enemy enemy, float viewAngle, float viewlDistance, float detectionDistance, Transform eye, float speed, float rotationSpeed, Transform target)
    {
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();

        _viewAngle = viewAngle;
        _viewlDistance = viewlDistance;
        _detectionDistance = detectionDistance;
        _eye = eye;

        _navMeshAgent.speed = speed;
        _navMeshAgent.angularSpeed = rotationSpeed;

        _startPos = enemy.transform.position;
        _target = target;
    }

    public void UpdateAI()
    {
        var distance = Vector3.Distance(_target.position, _eye.position);

        if(distance <= _detectionDistance && IsInVew())
        {
            Debug.Log("----------------------------DETECTED----------------------");
            _navMeshAgent.SetDestination(_target.position);
        }
        else
        {
            Debug.Log("----------------------------unDetected----------------------");
            _navMeshAgent.SetDestination(_startPos);
        }

        if (_navMeshAgent.hasPath)
        {
            IsMoving = true;
            Debug.Log("IsMoving = true;");
        }
        else
        {
            IsMoving = false;
            Debug.Log("IsMoving = false;");
        }
    }

    private bool IsInVew()
    {
        var angle = Vector3.Angle(_eye.forward, _target.position - _eye.position);

        if(Physics.Raycast(_eye.position, _target.position - _eye.position, out var hit, _viewlDistance))
        {
            if (angle <= _viewAngle/2 )
            {
                return true;
            }
            else return false;
        }
        else return false;
    }
}
