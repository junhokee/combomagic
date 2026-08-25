using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ElectricBehavior : TraitBehavior
{

    public override void AfterAttack(int amount, TraitInstance instance, Card sourceCard)
    {

        foreach(Enemy e in CombatManager.Instance.enemies)
        {
            if(e == null)
            {
                return;
            }
            BonusDamageAction action = new BonusDamageAction(e, math.max(1, (int)(amount * (0.1 + 1f/100 * instance.stacks))), sourceCard);
            ActionQueue.Instance.Enqueue(action);
        }
        
    }

}
