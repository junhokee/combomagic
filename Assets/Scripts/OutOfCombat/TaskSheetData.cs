using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using SerializeReferenceEditor;
using System;

[CreateAssetMenu(menuName = "Data/Task")]
public class TaskSheetData : ScriptableObject
{
    public string title;
    public string description;
    public Sprite image;
    public List<EnemyData> enemies;
    public List<Vector3> positions;
    public GameObject taskSheetFab;
    public Boolean conditions;
    public int stage;
    public int reward;
    

}