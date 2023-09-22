using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation 
{
    private Animator _animator;
    private bool _isMoving = false;
    
    protected readonly int Die = Animator.StringToHash("Die");
    protected readonly int Move = Animator.StringToHash("Move");
    protected readonly int Attack = Animator.StringToHash("Attack");

    public void Initialized(Animator animator)
    {
        _animator = animator;
    }

    public void DieAnim()
    {
        _animator.SetTrigger(Die);
    }

    public void MoveAnimStart()
    {
        if (!_isMoving)
        {
           // Debug.Log("NON _isMoving");
            _animator.SetBool(Move, true);
            _isMoving = true;
        }
    }

    public void MoveAnimStop()
    {
        if (_isMoving)
        {
            //Debug.Log("_isMoving");
            _animator.SetBool(Move, false);
            _isMoving = false;
        }
    }

    public void AttackAnim()
    {
        _animator.SetTrigger(Attack);
    }

    
}
