using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Card")]
public class CardData : ScriptableObject
{
    public string title;
    public string description;
    public Sprite image;
    public List<Traits> baseTraits;
    

}