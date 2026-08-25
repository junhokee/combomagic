using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using SerializeReferenceEditor;

[CreateAssetMenu(menuName = "Data/EnemyMove")]
[System.Serializable]
public class EnemyMoveData : ScriptableObject
{
    public string title;
    public string description;
    public Sprite image;
    public List<Traits> baseTraits;
    public bool isAttack;
    [SerializeReference, SR] public List<Effect> effects;
    

}