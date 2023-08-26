using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [Inject]
    private readonly CameraPoint _cameraPoint;

    private Transform _target;
    
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Enemy _enemy;

    public void Init()
    {
        _slider.maxValue = _enemy.GetCurrMaxHealth();
        _target = _cameraPoint.GetComponentInChildren<Camera>().transform;
    }

    private void FixedUpdate()
    {
        transform.LookAt(_target.position);
        _slider.value = _enemy.GetCurrHealth();
    }
}
