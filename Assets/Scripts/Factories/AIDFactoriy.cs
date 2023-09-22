using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AIDFactoriy
{
    private readonly List<AIDTrigger> _aids = new List<AIDTrigger>();

    [Inject]
    private AIDTrigger.Pool _aidPool;

    public AIDTrigger SpawnAID(Transform transform)
    {
        var aid = _aidPool.Spawn();
        _aids.Add(aid);
        aid.transform.position = transform.position;
        aid.Restart();
        return aid;
    }

    public void DeSpawnAID(AIDTrigger aid)
    {
        _aidPool.Despawn(aid);
        _aids.Remove(aid);
        aid.DeSpawn();
    }
}
