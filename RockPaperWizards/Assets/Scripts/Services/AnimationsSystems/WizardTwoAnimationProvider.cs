using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTwoAnimationProvider : IAnimationService
{
    Animator anim;

    public void Initialize()
    {
        //anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationYouWanttoLoad");
    }

    public void Unitialize()
    {
        anim.runtimeAnimatorController = null;
    }

    public void PlayWinAnimation()
    {
        //anim.Play("StateName");
    }

    public void PlayLoseAnimation()
    {
        //anim.Play("StateName");
    }

    public void PlayIdleAnimation()
    {
        //anim.Play("StateName");
    }

    public void PlayAttackAnimation()
    {
        //anim.Play("StateName");
    }
}
