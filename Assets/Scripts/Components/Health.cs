using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
   public float CurrentHealth { get; private set; }

    public event Action DeathE;

    public void Initialized(float startHealth)
    {
        CurrentHealth = startHealth;
    }

    public void CangeHealth(float value)
    {
        CurrentHealth += value;

        if(CurrentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        DeathE?.Invoke();
    }

}
