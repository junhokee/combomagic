using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAction : GameAction
{
    private ICardTarget target;
    private int amount;
    private int add = 0;
    private double mult = 1;
    private Card sourceCard;

    public DamageAction(ICardTarget target, int amount, Card sourceCard)
    {
        this.target = target;
        this.amount = amount;
        this.sourceCard = sourceCard;
    }

    public override IEnumerator Execute()
    {
        foreach(TraitInstance traitInstance in TraitManager.Instance.activeTraits)
        {
            add = traitInstance.behavior.ModifyAdd(add, traitInstance, sourceCard);
            
        }
        foreach(TraitInstance traitInstance in TraitManager.Instance.activeTraits)
        {
            mult = traitInstance.behavior.ModifyMult(mult, traitInstance, sourceCard);
            
        }

        
        Debug.Log("Damage done");
        target.ReceiveDamage((int)((amount + add) * mult));
        foreach(TraitInstance traitInstance in TraitManager.Instance.activeTraits)
        {
            traitInstance.behavior.AfterAttack((int)((amount + add) * mult), traitInstance, sourceCard);
            
        }
        yield return new WaitForSeconds(0.3f);
    }
}
