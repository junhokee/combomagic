using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardTarget{
    void ReceiveDamage(int amount);
    void DragCard();
    void HoverCard();
    bool IsValidTarget(Card card);
}
