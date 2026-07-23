using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitInstance
{
    public  Traits data {get; private set;}
    

    public int stacks;
    public Sprite sprite;

    public TraitInstance(Traits data, int stacks = 1)
    {
        this.data = data;
        this.stacks = stacks;
        sprite = data.image;
            Debug.Log($"TraitInstance created: data={data}, data.image={data.image}, sprite={sprite}");

    }

    public void Activate(int stacks)
    {
        
    }
}
