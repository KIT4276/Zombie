using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private List<Enemy> _enemies = new List<Enemy>();

    [SerializeField]
    private List<Transform> _enemiesSpawnPoints;

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
        foreach(var point in _enemiesSpawnPoints)
        {
            var enemy = _enemyFactoriy.SpawnEnemy(point);
            _enemies.Add(enemy);
        }
    }
}
