using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTraitAction : GameAction
{
    private int amount;
    private Traits trait;

    public AddTraitAction(Traits trait, int amount)
    {
        this.trait = trait;
        this.amount = amount;
    }
    public override IEnumerator Execute()
    {
        TraitManager.Instance.AddTrait(trait, amount);
        yield return null;
    }
}
