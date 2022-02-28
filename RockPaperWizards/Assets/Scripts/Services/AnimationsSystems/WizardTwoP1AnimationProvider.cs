using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTwoP1AnimationProvider : ScriptableObject, IAnimationService
{
    Animator anim;

    public void Initialize()
    {
        //anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationYouWanttoLoad");
    }

    public void Unitialize()
    {
        //anim.runtimeAnimatorController = null;
    }

    public void PlayIdleAnimation()
    {
        //anim.Play("Wizard1IdleP1");
    }
    public void PlayAttackMiddleWaterAnimation()
    {
        //anim.Play("Wizard1P1AttackWaterMiddle");
    }
    public void PlayAttackMiddleFireAnimation()
    {
        //anim.Play("Wizard1P1AttackFireMiddle");
    }
    public void PlayAttackMiddlePlantAnimation()
    {
        //anim.Play("Wizard1P1AttackPlantMiddle");
    }
    public void PlayAttackToPlayerWaterAnimation()
    {
        //anim.Play("Wizard1P1AttackWaterToPlayer");
    }
    public void PlayAttacktoPlayerFireAnimation()
    {
        //anim.Play("Wizard1P1AttackFireToPlayer");
    }
    public void PlayAttacktoPlayerPlantAnimation()
    {
        //anim.Play("Wizard1P1AttackPlantToPlayer");
    }
}
