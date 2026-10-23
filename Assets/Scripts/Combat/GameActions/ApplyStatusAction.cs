using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class ApplyStatusAction : GameAction
{
    private int stacks;
    private int duration;
    private StatusData statusData;
    private ICardTarget target;

    public ApplyStatusAction(ICardTarget target, ICardTarget user, IActionSource source, StatusData statusData, int stacks, int duration)
    {
        this.stacks = stacks;
        this.duration = duration;
        this.statusData = statusData;
        this.target = target;
    }
    public override IEnumerator Execute()
    {
         if (target == null)
    {
        Debug.LogError("ApplyStatusAction: target is NULL!");
        yield break;
    }

    if (target.StatusEffectManager == null)
    {
        Debug.LogError("ApplyStatusAction: StatusEffectManager is NULL!");
        yield break;
    }

    if (statusData == null)
    {
        Debug.LogError("ApplyStatusAction: statusData is NULL!");
        yield break;
    }
        target.StatusEffectManager.AddEffect(statusData, stacks, duration);   
        yield return null;
    }
}
