using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemiesAI 
{
    private NavMeshAgent _navMeshAgent;

    private float _viewAngle;
    private float _viewlDistance;
    private float _detectionDistance;
   // private float _attackDistance;
    private Transform _eye;

    private Transform _target;

    private Vector3 _startPos;

    public bool IsMoving { get; private set; }
    public bool IsDetected { get; private set; }

    public event Action AttackE;

    public void Initialized(Enemy enemy, float viewAngle, float viewlDistance, float detectionDistance, Transform eye,
        float speed, float rotationSpeed, Transform target, float stoppingDistance)
    {
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();

        _viewAngle = viewAngle;
        _viewlDistance = viewlDistance;
        _detectionDistance = detectionDistance;
        _eye = eye;
        //_attackDistance = attackDistance;

        _navMeshAgent.speed = speed;
        _navMeshAgent.angularSpeed = rotationSpeed;
        _navMeshAgent.stoppingDistance = stoppingDistance;

        _startPos = enemy.transform.position;
        _target = target;
    }

    public void UpdateAI()
    {
        var distance = Vector3.Distance(_target.position, _eye.position);

        if(distance <= _detectionDistance && IsInVew())
            SetTarget(true);
        else
            SetTarget(false);

        if (distance >_navMeshAgent.stoppingDistance && IsDetected)
            IsMoving = true;
        else
        {
            IsMoving = false;
            AttackE?.Invoke();
        }
    }

    private bool IsInVew()
    {
        var angle = Vector3.Angle(_eye.forward, _target.position - _eye.position);

        if(Physics.Raycast(_eye.position, _target.position - _eye.position, _viewlDistance))
        {
            if (angle <= _viewAngle/2 )
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    public void SetTarget(bool isPlayer)
    {
        if (isPlayer)
        {
            _navMeshAgent.SetDestination(_target.position);
        }
        else
            _navMeshAgent.SetDestination(_startPos);

        IsDetected = isPlayer;
    }
}
