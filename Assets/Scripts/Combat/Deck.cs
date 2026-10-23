using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static Deck Instance;
    private List<Card> drawPile = new List<Card>();
    private List<Card> discardPile = new List<Card>();

    public void Start()
    {
        Instance = this;
    }
    public void BuildDeck(List<Card> startingCards)
    {
        foreach (Card c in startingCards)
            drawPile.Add(c); // Card instances created ONCE here, at deck-building time

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
