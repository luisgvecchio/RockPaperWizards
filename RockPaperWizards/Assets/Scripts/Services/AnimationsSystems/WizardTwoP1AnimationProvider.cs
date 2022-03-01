using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTwoP1AnimationProvider : IAnimationService
{
    Animator anim;

    public void Initialize()
    {
        anim = GameObject.FindGameObjectWithTag("P1Holder").GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Wizard2P1/Wizard2P1");
    }

    public void Unitialize()
    {
        anim = GameObject.FindGameObjectWithTag("P1Holder").GetComponent<Animator>();
        anim.runtimeAnimatorController = null;
    }

    public void PlayIdleAnimation()
    {
        anim.Play("Wizard2IdleP1");
    }
    public void PlayAttackMiddleWaterAnimation()
    {
        anim.Play("Wizard2P1AttackWaterMiddle");
    }
    public void PlayAttackMiddleFireAnimation()
    {
        anim.Play("Wizard2P1AttackFireMiddle");
    }
    public void PlayAttackMiddlePlantAnimation()
    {
        anim.Play("Wizard2P1AttackPlantMiddle");
    }
    public void PlayAttackToPlayerWaterAnimation()
    {
        anim.Play("Wizard2P1AttackWaterToPlayer");
    }
    public void PlayAttacktoPlayerFireAnimation()
    {
        anim.Play("Wizard2P1AttackFireToPlayer");
    }
    public void PlayAttacktoPlayerPlantAnimation()
    {
        anim.Play("Wizard2P1AttackPlantToPlayer");
    }
}
