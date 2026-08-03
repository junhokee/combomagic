using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitInstance
{
    public  Traits data {get; private set;}
    

    public int stacks;
    public Sprite sprite;
    public TraitBehavior behavior;

    public TraitInstance(Traits data, int stacks = 1)
    {
        this.data = data;
        this.stacks = stacks;
        behavior = data.behavior;
        sprite = data.image;

    }

}
