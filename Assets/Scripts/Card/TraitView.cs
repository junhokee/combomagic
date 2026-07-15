using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TraitView : MonoBehaviour
{

    public int stacks;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Sprite sprite;

    public void Initialize(TraitInstance traitInstance)
    {
        this.stacks = traitInstance.stacks;
        this.sprite = traitInstance.sprite;
        spriteRenderer.sprite = sprite; 
    }

}
