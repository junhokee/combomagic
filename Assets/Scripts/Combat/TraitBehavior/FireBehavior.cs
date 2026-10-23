using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBehavior : TraitBehavior
{
    public override double ModifyMult(double mult, TraitInstance instance, Card sourceCard)
    {
        return mult + 5 * instance.stacks;
    }

    public void OnTurnStart()
    {
        
    }
}
