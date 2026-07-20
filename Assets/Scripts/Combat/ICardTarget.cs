using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardTarget{
    void ReceiveCard(Card card);
    void DragCard();
    void HoverCard();
    bool IsValidTarget(Card card);
}
