using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAction : GameAction
{
    private ICardTarget target;
    private int amount;

    public DamageAction(ICardTarget target, int amount)
    {
        this.target = target;
        this.amount = amount;
    }

    public override IEnumerator Execute()
    {
        Debug.Log("Damage done");
        target.ReceiveDamage(amount);
        yield return new WaitForSeconds(0.3f);
    }
}
