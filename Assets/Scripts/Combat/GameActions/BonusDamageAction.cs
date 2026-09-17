using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDamageAction : GameAction
{
    private ICardTarget target;
    private int amount;
    private Card sourceCard;

    public BonusDamageAction(ICardTarget target, int amount, IActionSource source)
    {
        this.target = target;
        this.amount = amount;
        this.sourceCard = (Card)source;
    }

    public override IEnumerator Execute()
    {
         Debug.Log("bonus damage " + amount);

        if (target == null)
        {
            Debug.LogError("BonusDamageAction: target is NULL!");
            yield break;
        }

        target.ReceiveDamage(amount);

        yield return new WaitForSeconds(0.3f);
    }
}
