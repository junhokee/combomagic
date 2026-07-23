using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AddTraitEffect : CardEffect
{
    public Traits trait;

    public int amount;

    public override GameAction CreateAction(ICardTarget target, Card sourceCard)
    {
        return new AddTraitAction(trait, amount);
    }
}
