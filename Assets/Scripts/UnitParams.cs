using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParams : MonoBehaviour
{
    [SerializeField]
    private float _startHealth;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _attackValue;

    #region Get

    public float GetStartHealth() => _startHealth;

    public float GetMoveSpeed() => _moveSpeed;

    public float GetAttackValue() => _attackValue;


    #endregion Get
}
