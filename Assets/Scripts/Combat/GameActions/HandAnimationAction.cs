using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationAction : GameAction
{
    public Animator hand;
    private string animation;
    private float animationTime;

    public HandAnimationAction(string animation, float animationTime)
    {
        this.animation = animation;
        this.animationTime = animationTime;
    }

    public override IEnumerator Execute()
    {
        HandAnimator.Instance.Play(animation);

        yield return new WaitForSeconds(animationTime);
    }
}
