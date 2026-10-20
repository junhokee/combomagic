using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public GameObject enemyPrefab;
    public EnemyData fiyadata;

    void Awake()
    {
        Instance = this;
        
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
