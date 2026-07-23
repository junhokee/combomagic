using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICardTarget
{
    [SerializeField] private Health health;

    public bool IsValidTarget(Card card)
    {
      if(!health.IsDead && card.isAttack)
        {
            
            return true;
        }  
        Debug.Log("enemy????");
        return false;
    } 

    public void ReceiveDamage(int amount)
    {
        health.TakeDamage(amount);
    }

    public void HoverCard()
    {
        
    }
    public void DragCard()
    {
        
    }


    public void ReceiveCard(Card card)
    {
        
    }
}