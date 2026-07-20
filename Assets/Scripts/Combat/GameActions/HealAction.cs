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
        Debug.Log("Healing done");
        //target.receiveDamage
        yield return new WaitForSeconds(0.3f);
    }
}
