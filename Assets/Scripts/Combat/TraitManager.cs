using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TraitManager : MonoBehaviour
{
    public List<TraitInstance> activeTraits = new List<TraitInstance>();
    public UnityEvent<List<TraitInstance>> TraitsChangedEvent;
    public static TraitManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public void AddTrait(Traits trait, int stacks)
    {

        TraitInstance existing = activeTraits.Find(t => t.data == trait);
         if (existing != null)
        {
            existing.stacks += stacks;
        }
        else
        {
            activeTraits.Add(new TraitInstance(trait, stacks));
        }

        TraitsChangedEvent.Invoke(activeTraits);
    }

    public int getTraitCount()
    {
        return activeTraits.Count;
    }
    public void RemoveTrait(Traits trait, int stacks)
    {
        TraitInstance existing = activeTraits.Find(t => t.data == trait);
        if (existing == null) return;

        existing.stacks -= stacks;

        if (existing.stacks <= 0)
            activeTraits.Remove(existing);

        TraitsChangedEvent.Invoke(activeTraits);
    }

     public void ResetTrait()
    {
        foreach(TraitInstance t in activeTraits)
        {
            if(t == null)
            {
                return;
            }
            activeTraits.Remove(t);
        }
    }

    
    



}
