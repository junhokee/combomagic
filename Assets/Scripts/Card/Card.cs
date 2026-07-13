using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public CardData data;
    public string Title => data.title;
    public string Description => data.description;
    public Sprite image => data.image;
    public List<Traits> traits;
    

    public Card(CardData cardData)
    {
        this.data = cardData;
        traits = new List<Traits>();
        foreach (Traits t in cardData.baseTraits) 
        { 
            traits.Add(t);
        }
    }
    public void Play()
    {
        
    }

}
