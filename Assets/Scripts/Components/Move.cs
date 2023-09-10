using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    protected float _moveSpeed;
    protected GameObject _unit;

    protected int _layerMask;
    protected RaycastHit _hit;
    protected Ray _ray;
    protected Vector3 _targetForLookAt;
    


    public void Initialized(float speed, GameObject unit)
    {
        _moveSpeed = speed;
        _unit = unit;
    }

    public void ChangeMooveSpeed(float value)
    {
        _moveSpeed += value;
    }

    public virtual void OnMove(Vector3 direction) { }

    public virtual void OnRotate() { }
}
