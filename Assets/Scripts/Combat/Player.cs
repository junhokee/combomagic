using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health health;
    public HandType handType;
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

    
}
