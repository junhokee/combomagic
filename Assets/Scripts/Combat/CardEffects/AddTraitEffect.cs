using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AddTraitEffect : Effect
{
    public override EffectTiming timing => EffectTiming.Immediate;

    public Traits trait;

    public int amount;

    public override GameAction CreateAction(ICardTarget target, ICardTarget user, IActionSource source)
    {
        return new AddTraitAction(trait, amount);
    }
}
