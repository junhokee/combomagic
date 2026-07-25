using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public CardData data;
    public string Title => data.title;
    public string Description => data.description;
    public Sprite image => data.image;
    public CardType cardType => data.cardtype;
    public bool isAttack => data.isAttack;
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
    public void Play(ICardTarget target)
    {
        foreach (CardEffect effect in data.effects)
        {
            Debug.Log("aufshaf");
            GameAction action = effect.CreateAction(target, this);
            ActionQueue.Instance.Enqueue(action);
        }
        
        ComboManager.Instance.RegisterCardPlayed(this);
    }



}
