using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDTrigger : BaseTrigger
{
    [SerializeField]
    private float _recoveryAmount;
    public float AIDTriggerEnter()
    {
        return _recoveryAmount;
    }
}
