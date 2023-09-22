using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float _startHealth;


    public float CurrentHealth { get; private set; }

    public event Action DeathE;

    public void Initialized(float startHealth)
    {
        _startHealth = startHealth;
        CurrentHealth = startHealth;
    }

    public void CangeHealth(float value)
    {
        CurrentHealth += value;

        if(CurrentHealth <= 0)
        {
            Death();
        }
        else if (CurrentHealth >= _startHealth)
        {
            CurrentHealth = _startHealth;
        }
    }

    private void Death()
    {
        DeathE?.Invoke();
    }

}
