using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ComboManager : MonoBehaviour
{
    public Traits usableTrait;
    public Traits lastUsedTrait;
    public static ComboManager Instance;
    public UnityEvent ComboStateChangedEvent;
    public int additive;
    public int mult;
    
    public void Awake()
    {
        Instance = this;
    }

    public void RegisterCardPlayed(Card card)
    {
        if (lastUsedTrait == null)
        {
            lastUsedTrait = card.traits[0]; 
            if(card.traits.Count > 1)
            {
                usableTrait = card.traits[1];
            }
            else
            {
                usableTrait = null;
            }
        }  else 
        {
            lastUsedTrait = usableTrait;
            if(card.traits.Count > 1)
            {
                foreach(Traits t in card.traits)
                {
                    if(t != usableTrait)
                    {
                        usableTrait = t;
                        break;
                    }
                }
            }
            else
            {
                usableTrait = null;
            }
        }

        GameAction action = AddTrait();
        ActionQueue.Instance.Enqueue(action);

        ComboStateChangedEvent.Invoke();
            
    }

    public int CalculateDamage(int amount)
    {
        //additive += trait.additive
        //mult *= trait.mult
        return (amount + additive) * mult;
        
    }

    public bool CanPlay(Card card)
    {
        if (lastUsedTrait == null) return true;

        if (usableTrait != null)
        {
            return card.traits.Contains(usableTrait);
        }
        else
        {
            return false;
        }
            
    }

    public void ResetCombo()
    {
        TraitManager.Instance.ResetTrait();
        lastUsedTrait = null;
        usableTrait = null;
    }

    public GameAction AddTrait()
    {
        Debug.Log("does this work");
        return new AddTraitAction(lastUsedTrait, 1);
    }
}
