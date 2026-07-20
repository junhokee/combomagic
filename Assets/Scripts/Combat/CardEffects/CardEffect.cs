using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class CardEffect
{
    public abstract GameAction CreateAction(ICardTarget target, Card sourceCard);
}
