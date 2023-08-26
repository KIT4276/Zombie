using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitParams), (typeof(Animator)))]
public class BaseUnit : MonoBehaviour
{
    protected UnitParams _params;
    protected Health _health;
    protected Move _move;
    protected Attack _attack;
    protected Animation _animation;

    public bool IsAlive { get; private set; }

    protected virtual void Start()
    {
        IsAlive = true;
        _params = GetComponent<UnitParams>();

        _health = new Health();
        _move = new Move();
        _attack = new Attack();
        _animation = new Animation();

        _health.Initialized(_params.GetStartHealth());
        _move.Initialized(_params.GetMoveSpeed(), this.gameObject);
        _attack.Initialized(_params.GetAttackValue());
        _animation.Initialized(GetComponent<Animator>());

        _health.DeathE += Death;
    }

    

    protected void UnitAttack()
    {
        _attack.OnAttack();
        _animation.AttackAnim();
    }

    protected void TakeDamage(float damage)
    {
        _health.CangeHealth(-damage);
    }

    protected virtual void Death()
    {
        if (IsAlive)
        {
            _animation.DieAnim();
            IsAlive = false;
        }
    }

    public float GetCurrMaxHealth() => _params.GetStartHealth();

    public float GetCurrHealth() => _health.CurrentHealth;

    public UnitParams GetParams() => _params;
}
