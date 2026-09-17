using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationAction : GameAction
{
    public Animator hand;
    private string animation;

    public HandAnimationAction(string animation)
    {
        this.animation = animation;
    }

    public override IEnumerator Execute()
    {
        HandAnimator.Instance.Play(animation);
        Debug.Log("is it working" + animation);

        yield return new WaitForSeconds(0.9f);
    }
}
