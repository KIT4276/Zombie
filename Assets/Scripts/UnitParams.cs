using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParams : MonoBehaviour
{
    [SerializeField]
    protected float _startHealth;
    [SerializeField]
    protected float _moveSpeed;
    [SerializeField]
    protected float _attackValue;
    [SerializeField]
    protected float _attackTime;
    [SerializeField]
    private float _coolDown = 1.5f;

    #region Get

    public float GetStartHealth() => _startHealth;

    public float GetMoveSpeed() => _moveSpeed;

    public float GetAttackValue() => _attackValue;

    public float GetAttackTime() => _attackTime;

    public float GetCoolDown() => _coolDown;


    #endregion Get
}
