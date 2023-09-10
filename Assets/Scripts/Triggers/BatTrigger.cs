using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    [SerializeField]
    private UnitType _unitType;

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    public UnitType GetUnitType() => _unitType;
}
