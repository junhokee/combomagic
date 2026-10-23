using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public List<Status> activeEffects = new();
    public bool isElectrified = false;
    public void AddEffect(StatusData data, int stacks, int duration) {
        Status existing =
            activeEffects.Find(e => e.data == data);

        if (existing != null)
        {
            existing.stacks += stacks;
            existing.duration = Mathf.Max(existing.duration, duration);
            return;
        }

        Status instance =
            new Status(data, this, stacks, duration);
        
        activeEffects.Add(instance);
        data.OnApply(instance);
    }

    public void OnTurnStart()
    {
        foreach (var effect in activeEffects.ToArray())
        {
            effect.data.OnTurnStart(effect);
        }
    }

    public bool HasStatus(string statusName)
{
    return activeEffects.Exists(effect => effect.data.title == statusName);
}

    public void OnTurnEnd()
    {
        foreach (var effect in activeEffects.ToArray())
        {
            effect.data.OnTurnEnd(effect);

            effect.duration--;

            if (effect.duration <= 0)
            {
                effect.data.OnRemove(effect);
                activeEffects.Remove(effect);
            }
        }
    }
}