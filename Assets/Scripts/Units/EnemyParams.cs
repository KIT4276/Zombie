using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParams : UnitParams
{
    [SerializeField, Range(0, 360)]
    private float _viewAngle;
    [SerializeField]
    private float _viewlDistance;
    [SerializeField]
    private float _detectionDistance;
    [SerializeField]
    private float _stoppingDistance;
    //[SerializeField]
    //private float _attackDistance;
    [SerializeField]
    private Transform _eye;

    [SerializeField]
    private float _rotationSpeed;

    #region Get

    public float GetVewAngle() => _viewAngle;

    public float GetViewlDistance() => _viewlDistance;

    public float GetDetectionDistance() => _detectionDistance;

    public Transform GetEye() => _eye;

    public float GetRotationSpeed() => _rotationSpeed;

    public float GetStoppingDistance() => _stoppingDistance;

    //public float GetAttackDistance() => _attackDistance;

    #endregion Get
}
