using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyData fiyadata;

    void Start()
    {
        SpawnEnemy(fiyadata, new Vector3(2.37f, 3.9f, 113.9f));
    }

    public Enemy SpawnEnemy(EnemyData data, Vector3 position)
    {
        GameObject obj = Instantiate(enemyPrefab, position, Quaternion.identity);
    
        Enemy enemy = obj.GetComponent<Enemy>();
        enemy.Initialize(data);
        CombatManager.Instance.enemies.Add(enemy);
        return enemy;
        
    }
}
