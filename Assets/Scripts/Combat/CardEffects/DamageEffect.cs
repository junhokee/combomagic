using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class DamageEffect : Effect
{
    public override EffectTiming timing => EffectTiming.Immediate;

    public int amount;

    public override GameAction CreateAction(ICardTarget target, ICardTarget user, IActionSource source)
    {
        Debug.Log("is this working?");
        return new DamageAction(target, amount, source);
    }
}
