using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDamageAction : GameAction
{
    private ICardTarget target;
    private int amount;
    private Card sourceCard;

    public BonusDamageAction(ICardTarget target, int amount, Card sourceCard)
    {
        this.target = target;
        this.amount = amount;
        this.sourceCard = sourceCard;
    }

    public override IEnumerator Execute()
    {
        
        Debug.Log("bonus damage" + amount);
        target.ReceiveDamage(amount);
        yield return new WaitForSeconds(0.3f);
    }
}
