using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Move
{
    private CharacterController _charControl;

    public PlayerMove(CharacterController controller) => _charControl = controller;

    public override void OnMove(Vector3 direction)
    {
        _charControl.SimpleMove(direction * _moveSpeed);
    }

    public override void OnRotate()
    {
        _layerMask = 1 << 6;
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, 1000, _layerMask))
        {
            _targetForLookAt = new Vector3(_hit.point.x, _unit.transform.position.y, _hit.point.z);
        }

        _unit.transform.LookAt(_targetForLookAt);
    }
}
