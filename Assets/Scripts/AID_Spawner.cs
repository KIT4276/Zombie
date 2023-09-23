using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AID_Spawner : MonoBehaviour
{
    private List<AIDTrigger> _aids = new List<AIDTrigger>();

    [SerializeField]
    private List<Transform> _aidSpawnPoints;
    [SerializeField]
    private float _spawnDelay = 20;

    [Inject]
    private AIDFactoriy _aIDFactoriy;

    public void SpawnStartAIDs()
    {
        //foreach (var point in _aidSpawnPoints)
        //{
        //    SpawnAID(point);
        //}

        StartCoroutine(SpawnDelayRoutine());
    }

    private IEnumerator SpawnDelayRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            SpawnAID(RandomPoint());
        }
    }

    private void SpawnAID(Transform point)
    {
        var aid = _aIDFactoriy.SpawnAID(point);
        _aids.Add(aid);
        Debug.Log("SpawnAID " + point.name);
    }

    private Transform RandomPoint()
    {
        var r = Random.Range(0, _aidSpawnPoints.Count);
        return _aidSpawnPoints[r];
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
