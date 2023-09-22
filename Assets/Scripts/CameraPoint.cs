using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraPoint : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private Transform _camera;

    [Inject]
    private Player _target;

    private void Start()
    {
        transform.parent = null;
    }

    private void FixedUpdate()
        => transform.position = Vector3.Lerp(transform.position, _target.transform.position, _speed * Time.deltaTime);

    public Transform GetCameraTransform()
    {
        if (_camera == null) return transform;
        else return _camera;
    }
}
