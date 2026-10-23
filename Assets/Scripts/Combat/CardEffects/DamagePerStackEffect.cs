using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class DamagePerStackEffect : Effect
{
    public override EffectTiming timing => EffectTiming.Immediate;

    public int amount;
    public Traits traits;

    public override GameAction CreateAction(ICardTarget target, ICardTarget user, IActionSource source)
    {
        Debug.Log("is this working?");
        amount = amount * TraitManager.Instance.getStack(traits);
        return new DamageAction(target, amount, source);
    }
}
