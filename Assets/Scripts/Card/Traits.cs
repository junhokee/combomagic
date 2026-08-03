using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using SerializeReferenceEditor;

[CreateAssetMenu(menuName = "Data/Traits")]
public class Traits : ScriptableObject
{
    [SerializeReference, SR] public TraitBehavior behavior;
    public string title;
    public Sprite image;
    
}