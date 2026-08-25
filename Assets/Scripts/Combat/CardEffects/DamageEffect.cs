using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class DamageEffect : Effect
{
    public int amount;

    public override GameAction CreateAction(ICardTarget target, IActionSource source)
    {
        Debug.Log("is this working?");
        return new DamageAction(target, amount, source);
    }
}
