using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : GameAction
{
    private ICardTarget target;
    private int amount;

    public HealAction(ICardTarget target, int amount)
    {
        this.target = target;
        this.amount = amount;
    }

    public override IEnumerator Execute()
    {

        target.ReceiveHeal(amount);
        yield return new WaitForSeconds(0.3f);
    }
}
