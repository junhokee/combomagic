using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class BonusDamageEffect : CardEffect
{
    public int amount;

    public override GameAction CreateAction(ICardTarget target, Card sourceCard)
    {
        Debug.Log("is this working?");
        return new BonusDamageAction(target, amount, sourceCard);
    }
}
