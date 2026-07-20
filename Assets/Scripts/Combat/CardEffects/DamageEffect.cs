using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class DamageEffect : CardEffect
{
    public int amount;

    public override GameAction CreateAction(ICardTarget target, Card sourceCard)
    {
        return new DamageAction(target, amount);
    }
}
