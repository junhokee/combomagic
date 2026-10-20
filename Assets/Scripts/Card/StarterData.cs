using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using SerializeReferenceEditor;

[CreateAssetMenu(menuName = "Data/Starter")]
public class StarterData : ScriptableObject
{
    public string title;
    public List<CardData> cards;
    

}