using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBehavior : TraitBehavior
{

    public override void AfterAttack(int amount, TraitInstance instance, Card sourceCard)
    {

        foreach(Enemy e in CombatManager.Instance.enemies)
        {
            BonusDamageAction action = new BonusDamageAction(e, (int)(amount * (0.1 + 1f/100 * instance.stacks)), sourceCard);
            ActionQueue.Instance.Enqueue(action);
        }
        
    }

}
