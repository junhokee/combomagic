using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ApplyStatusEffect : Effect
{
    public override EffectTiming timing => EffectTiming.Immediate;

    public StatusData statusData;

    public int stacks;
    public int duration;

    public override GameAction CreateAction(ICardTarget target, ICardTarget user, IActionSource source)
    {
        return new ApplyStatusAction(target, user, source, statusData, stacks, duration);
    }
}
