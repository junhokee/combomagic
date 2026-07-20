using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Card")]
public class CardData : ScriptableObject
{
    public string title;
    public string description;
    public Sprite image;
    public List<Traits> baseTraits;
    public bool isAttack;
    public CardType cardtype;
    [SerializeReference] 
    public List<CardEffect> effects;
    

}