using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    private float _moveSpeed;
    private GameObject _player;

    private int _layerMask;
    private RaycastHit _hit;
    private Ray _ray;
    private Vector3 _targetForLookAt;


    public void Initialized(float speed, GameObject player)
    {
        _moveSpeed = speed;
        _player = player;
    }

    public void ChangeMooveSpeed(float value)
    {
        _moveSpeed += value;
    }

    public void OnMove(Vector3 direction)
    {
        _player.transform.position += direction * _moveSpeed * Time.deltaTime;
    }

    public void OnRotate()
    {
        _layerMask = 1 << 6;
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, 1000, _layerMask))
        {
            _targetForLookAt = new Vector3(_hit.point.x, _player.transform.position.y, _hit.point.z);
        }

        _player.transform.LookAt(_targetForLookAt);
    }
}
