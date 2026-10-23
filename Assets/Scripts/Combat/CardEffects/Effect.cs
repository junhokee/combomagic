using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Effect
{
    public abstract GameAction CreateAction(ICardTarget target, ICardTarget user, IActionSource source);
    public abstract EffectTiming timing { get; }
    
}
