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
            StatusEffectManager statusManager =
            e.GetComponent<StatusEffectManager>();

            if (statusManager == null || !statusManager.HasStatus("ElectrifiedStatus"))
            continue;
            BonusDamageAction action = new BonusDamageAction(e, math.max(1, (int)(instance.stacks/3)), sourceCard);
            ActionQueue.Instance.Enqueue(action);
        }
        
    }

}
