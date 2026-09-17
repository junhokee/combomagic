using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    public static HandAnimator Instance;

    [SerializeField]private Animator animator;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void Play(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}