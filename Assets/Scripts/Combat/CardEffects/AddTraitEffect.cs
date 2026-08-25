using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AddTraitEffect : Effect
{
    public Traits trait;

    public int amount;

    public override GameAction CreateAction(ICardTarget target, IActionSource source)
    {
        return new AddTraitAction(trait, amount);
    }
}
