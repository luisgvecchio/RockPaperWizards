using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTwoP2AnimationProvider : IAnimationService
{
    Animator anim;

    public void Initialize()
    {
        anim = GameObject.FindGameObjectWithTag("P2Holder").GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Wizard2P2/Wizard2P2");
    }

    public void Unitialize()
    {
        anim = GameObject.FindGameObjectWithTag("P2Holder").GetComponent<Animator>();
        anim.runtimeAnimatorController = null;
    }

    public void PlayIdleAnimation()
    {
        anim.Play("Wizard2IdleP2");
    }
    public void PlayAttackMiddleWaterAnimation()
    {
        anim.Play("Wizard2P2AttackWaterMiddle");
    }
    public void PlayAttackMiddleFireAnimation()
    {
        anim.Play("Wizard2P2AttackFireMiddle");
    }
    public void PlayAttackMiddlePlantAnimation()
    {
        anim.Play("Wizard2P2AttackPlantMiddle");
    }
    public void PlayAttackToPlayerWaterAnimation()
    {
        anim.Play("Wizard2P2AttackWaterToPlayer");
    }
    public void PlayAttacktoPlayerFireAnimation()
    {
        anim.Play("Wizard2P2AttackFireToPlayer");
    }
    public void PlayAttacktoPlayerPlantAnimation()
    {
        anim.Play("Wizard2P2AttackPlantToPlayer");
    }
}
