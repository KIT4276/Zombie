using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private List<Enemy> _enemies = new List<Enemy>();

    [SerializeField]
    private List<Transform> _enemiesSpawnPoints;
    [SerializeField]
    private float _spawnDelay = 20;

    [Inject]
    private EnemyFactoriy _enemyFactoriy;

    private void Awake()
    {
        foreach (var point in _enemiesSpawnPoints)
        {
            var r = Random.Range(0, 360);
            point.rotation = Quaternion.Euler(0, r, 0);
        }
    }

    public void SpawnStartEnemies()
    {
        StartCoroutine(SpawnDelayRoutine());
    }

    private IEnumerator SpawnDelayRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            SpawnEnemy(RandomPoint());
        }
    }

    private void SpawnEnemy(Transform point)
    {
        var enemy = _enemyFactoriy.SpawnEnemy(point);
        _enemies.Add(enemy);
        Debug.Log("SpawnEnemy " + point.name);
    }

    private Transform RandomPoint()
    {
        var r = Random.Range(0, _enemiesSpawnPoints.Count);
        return _enemiesSpawnPoints[r];
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
