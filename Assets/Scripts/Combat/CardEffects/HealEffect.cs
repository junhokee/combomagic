using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class HealEffect : Effect
{
    public int amount;

    public override GameAction CreateAction(ICardTarget target, IActionSource source)
    {
        return new HealAction(target, amount);
    }
}
