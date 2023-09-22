using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitParams), (typeof(Animator)))]
public class BaseUnit : MonoBehaviour
{
    protected UnitParams _params;
    protected Health _health;
    //protected Move _move;
    protected Attack _attack;
    protected Animation _animation;

    public bool IsAlive { get; private set; }

    protected virtual void Start()
    {
        IsAlive = true;
        _params = GetComponent<UnitParams>();

        _health = new Health(); // не нужно ли после деспавна вручную это удалять или не создавать каждый раз новые??
        
        _attack = new Attack();
        _animation = new Animation();

        _health.Initialized(_params.GetStartHealth());
        
        _attack.Initialized(_params.GetAttackTime(), _params.GetCoolDown());
        _animation.Initialized(GetComponent<Animator>());

        _health.DeathE += Death;
    }
    

    protected void UnitAttack()
    {
        if (IsAlive && !_attack.IsAttack)
        {
            _attack.OnAttack();
            _animation.AttackAnim();
        }
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

    protected virtual void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<BatTrigger>(out var b))
        //{
        //    Debug.Log(b);
        //    Debug.Log(b.GetUnitType());
        //}
        //if(other.GetComponentInParent<BaseUnit>() != null)
        //{
        //    Debug.Log("!= null");
        //    Debug.Log(GetComponentInParent<BaseUnit>().GetIsAttack());
        //}
        //Debug.Log("бита " + other.TryGetComponent<BatTrigger>(out var b));
        //Debug.Log("чья " + b.GetUnitType() );
        //Debug.Log("BaseUnit " + other.GetComponentInParent<BaseUnit>());
        //Debug.Log("Атакует " + other.GetComponentInParent<BaseUnit>().GetIsAttack());

        if (other.TryGetComponent<BatTrigger>(out var bat) && bat.GetUnitType() != _params.GetUnitType() && other.GetComponentInParent<BaseUnit>() != null && other.GetComponentInParent<BaseUnit>().GetIsAttack())
        {
            Debug.Log(this.name +  " Принял Удар " );
            TakeDamage(other.GetComponentInParent<BaseUnit>().GetParams().GetAttackValue());
        }
    }

    #region GetMethods

    public float GetCurrMaxHealth() => _params.GetStartHealth();

    public float GetCurrHealth() => _health.CurrentHealth;

    public UnitParams GetParams() => _params;

    public bool GetIsAttack() => _attack.IsAttack;

    #endregion    GetMethods

    private void OnDestroy()
    {
        _health.DeathE -= Death;
    }
}
