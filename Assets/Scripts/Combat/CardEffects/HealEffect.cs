using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class HealEffect : Effect
{
    public override EffectTiming timing => EffectTiming.Immediate;

    public int amount;

    public override GameAction CreateAction(ICardTarget target, ICardTarget user, IActionSource source)
    {
        return new HealAction(user, amount);
    }
}
