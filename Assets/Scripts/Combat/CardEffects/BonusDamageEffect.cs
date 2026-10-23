using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
[System.Serializable]

public class BonusDamageEffect : Effect
{
    public override EffectTiming timing => EffectTiming.Immediate;

    public int amount;

    public override GameAction CreateAction(ICardTarget target, ICardTarget user, IActionSource source)
    {
        Debug.Log("is this working?" + target);
        return new BonusDamageAction(target, amount, source);
    }
}