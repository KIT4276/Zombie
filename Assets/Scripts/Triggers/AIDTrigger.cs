using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AIDTrigger : BaseTrigger
{
    [SerializeField]
    private float _recoveryAmount;

    public void Restart()
    {

    }

    public float AIDTriggerEnter()
    {
        return _recoveryAmount;
    }

    public void DeSpawn()
    {

    }

    public class Pool : MonoMemoryPool<AIDTrigger> { }
}
