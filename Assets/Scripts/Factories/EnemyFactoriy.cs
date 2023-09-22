using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyFactoriy 
{
    private readonly List<Enemy> _enemies = new List<Enemy>();

    [Inject]
    private Enemy.Pool _enemiesPool;

    public Enemy SpawnEnemy(Transform transform)
    {
        Enemy enemy = _enemiesPool.Spawn();
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;
        enemy.Restart();
        _enemies.Add(enemy);
        return enemy;
    }

    public void DeSpawnEnemy(Enemy enemy)
    {
        _enemiesPool.Despawn(enemy);
        _enemies.Remove(enemy);
    }
}
