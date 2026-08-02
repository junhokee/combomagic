using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> drawPile = new List<Card>();
    private List<Card> discardPile = new List<Card>();

    public void BuildDeck(List<CardData> startingCards)
    {
        foreach (CardData data in startingCards)
            drawPile.Add(new Card(data)); // Card instances created ONCE here, at deck-building time

        Shuffle();
    }

    public Card DrawCard() // now returns Card, not CardData
    {
        if (drawPile.Count == 0)
            ReshuffleDiscardIntoDraw();

        if (drawPile.Count == 0) return null;

        Card card = drawPile[0];
        drawPile.RemoveAt(0);
        return card;
    }

    public void Discard(Card card)
    {
        discardPile.Add(card);
    }

    void ReshuffleDiscardIntoDraw()
    {
        drawPile.AddRange(discardPile);
        discardPile.Clear();
        Shuffle();
    }

    void Shuffle()
    {
        // Fisher-Yates or similar
    }
}
