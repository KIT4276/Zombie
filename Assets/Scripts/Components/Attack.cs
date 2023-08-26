using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Attack
{
    //private float _attackValue;
    private float _attackTime;
    private float _coolDown;

    public bool IsAttack { get; private set; }

    public void Initialized(float attackTime, float coolDown)
    {
        //_attackValue = attackvalue;
        _attackTime = attackTime;
        _coolDown = coolDown;
    }

    public void OnAttack()
    {
        IsAttack = true;
        //Debug.Log(" IsAttack = true;");
        _ = EndAttack();
    }

    private async Task EndAttack()
    {
        await Task.Delay(System.TimeSpan.FromSeconds(_coolDown));
        IsAttack = false;
       // Debug.Log(" IsAttack = false;");
    }
}
