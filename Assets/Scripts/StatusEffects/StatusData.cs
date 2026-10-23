using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using SerializeReferenceEditor;

[CreateAssetMenu(menuName = "Data/Status")]
public class StatusData : ScriptableObject
{
    public string title;
    public string description;
    public Sprite image;
    public int stack;
    public virtual void OnApply(Status instance) { }

    public virtual void OnTurnStart(Status instance) { }

    public virtual void OnTurnEnd(Status instance) { }
    public virtual void OnCardUsed(Status instance){ }

    public virtual void OnRemove(Status instance) { }
    

}