using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card: IActionSource
{
    public CardData data;
    public string Title => data.title;
    public string Description => data.description;
    public Sprite image => data.image;
    public CardType cardType => data.cardtype;
    public bool isAttack => data.isAttack;
    public List<Traits> traits;
    public string handAnimationTrigger;
    

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
        ActionQueue.Instance.Enqueue(new SwapGloveAction(data.handFab));
        if(data.cardtype == CardType.Monster)
        {
            
        }
        ActionQueue.Instance.Enqueue(new HandAnimationAction(data.handAnimationTrigger));
        foreach (Effect effect in data.effects)
        {

            GameAction action = effect.CreateAction(target, this);
            
            ActionQueue.Instance.Enqueue(action);

        }

        ComboManager.Instance.RegisterCardPlayed(this);
        
        
    }



}
