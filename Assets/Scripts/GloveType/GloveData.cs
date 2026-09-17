using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using SerializeReferenceEditor;

[CreateAssetMenu(menuName = "Data/Glove")]
public class GloveData : ScriptableObject
{
    public string name;
    public string description;
    public GameObject glovePrefab;
    
    [SerializeReference, SR] public List<Effect> passiveEffects;
    [SerializeReference, SR] public List<Effect> activeEffects;
    //
    public string handAnimationTrigger;
    

}