using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class HealEffect : CardEffect
{
    public int amount;

    public override GameAction CreateAction(ICardTarget target, Card sourceCard)
    {
        return new HealAction(target, amount);
    }
}
