using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AID_Spawner : MonoBehaviour
{
    private List<AIDTrigger> _aids = new List<AIDTrigger>();

    [SerializeField]
    private List<Transform> _aidSpawnPoints;

    [Inject]
    private AIDFactoriy _aIDFactoriy;

    private void Start()
    {
        SpawnStartAIDs();
    }

    private void SpawnStartAIDs()
    {
        foreach (var point in _aidSpawnPoints)
        {
            var aid = _aIDFactoriy.SpawnAID(point);
            _aids.Add(aid);
        }
    }
}
