using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour, ICardTarget
{
    public SpriteRenderer sr;

    public bool IsValidTarget(Card card){
        if(card.isAttack){
            return false;
        } else{
            return true;
        }
    }

    public void DragCard()
    {
        sr.color = Color.gray;
    }

    public void HoverCard(){
        sr.color = Color.red;
    }

    public void ReceiveDamage(int amount)
    {

    }

}
