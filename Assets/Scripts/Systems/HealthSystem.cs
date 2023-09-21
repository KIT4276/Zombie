using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    [Inject]
    private readonly Player _player;

    [SerializeField]
    private TextMeshProUGUI _healthText;

    private void FixedUpdate()
    {
        _healthText.text = _player.GetCurrHealth().ToString();
        if (_player.GetCurrHealth() == 0)
            _healthText.text = "0";
    }
}
