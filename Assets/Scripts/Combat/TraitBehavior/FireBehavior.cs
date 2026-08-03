using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBehavior : TraitBehavior
{
    public override int ModifyAdd(int add, TraitInstance instance, Card sourceCard)
    {
        return add + (int)Math.Pow(2, instance.stacks);
    }

    public void OnTurnStart()
    {
        
    }
}
