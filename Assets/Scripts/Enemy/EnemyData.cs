using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using SerializeReferenceEditor;

[CreateAssetMenu(menuName = "Data/NewEnemy")]
public class EnemyData : ScriptableObject
{
    public GameObject enemyPrefab;
    public int MaxHealth;
    public List<EnemyMoveData> possibleMoves;
    
    
    

}