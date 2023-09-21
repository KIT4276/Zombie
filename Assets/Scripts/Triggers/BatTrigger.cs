using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : BaseTrigger
{
    [SerializeField]
    private UnitType _unitType;

    public UnitType GetUnitType() => _unitType;
}
