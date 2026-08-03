using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class TraitBehavior
{
    public virtual void PlayAction(DamageAction action) {}
        
    public virtual int ModifyAdd(int add, TraitInstance instance, Card sourceCard){ return add;}
    public virtual double ModifyMult(double mult, TraitInstance instance, Card sourceCard){return mult;}


    public virtual void AfterAttack(int amount, TraitInstance instance, Card sourceCard) {}

    public virtual void OnTurnStart() {}
}
