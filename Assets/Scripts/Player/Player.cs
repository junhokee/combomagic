using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICardTarget
{
    [SerializeField] private Health health;
    public GameObject glove;
    void Awake()
    {
        Instance = this;
    }
    public HandType handType;
    public static Player Instance;
    public enum HandType
    {
        Hand,
        Monster,
        Corrupt,
        Ascend
    }
    
    public void ReceiveDamage(int amount)
    {
        health.TakeDamage(amount);
    }

    public Health getHealth()
    {
        return health;
    }


    public void DragCard()
    {
        
    }
    public void HoverCard()
    {
        
    }
    public bool IsValidTarget(Card card)
    {
        return false;
    }

    
}
