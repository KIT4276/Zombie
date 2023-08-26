using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Attack
{
    //private float _attackValue;
    private float _attackTime;

    public bool IsAttack { get; private set; }

    public void Initialized(float attackTime)
    {
        //_attackValue = attackvalue;
        _attackTime = attackTime;
    }

    public void OnAttack()
    {
        IsAttack = true;
        //Debug.Log(" IsAttack = true;");
        _ = EndAttack();
    }

    private async Task EndAttack()
    {
        await Task.Delay(System.TimeSpan.FromSeconds(_attackTime));
        IsAttack = false;
       // Debug.Log(" IsAttack = false;");
    }
}
