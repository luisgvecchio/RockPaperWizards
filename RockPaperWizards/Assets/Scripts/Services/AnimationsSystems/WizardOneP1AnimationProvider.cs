using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardOneP1AnimationProvider : IAnimationService
{
    Animator anim;

    public void Initialize()
    {
        anim = GameObject.FindGameObjectWithTag("P1Holder").GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Wizard1P1/Wizard1P1");
    }

    public void Unitialize()
    {
        anim = GameObject.FindGameObjectWithTag("P1Holder").GetComponent<Animator>();
        anim.runtimeAnimatorController = null;
    }

    public void PlayIdleAnimation()
    {
        anim.Play("Wizard1IdleP1");
    }
    public void PlayAttackMiddleWaterAnimation()
    {
        anim.Play("Wizard1P2AttackWaterMiddle");
    }
    public void PlayAttackMiddleFireAnimation()
    {
        anim.Play("Wizard1P2AttackFireMiddle");
    }
    public void PlayAttackMiddlePlantAnimation()
    {
        anim.Play("Wizard1P2AttackPlantMiddle");
    }
    public void PlayAttackToPlayerWaterAnimation()
    {
        anim.Play("Wizard1P2AttackWaterToPlayer");
    }
    public void PlayAttacktoPlayerFireAnimation()
    {
        anim.Play("Wizard1P2AttackFireToPlayer");
    }
    public void PlayAttacktoPlayerPlantAnimation()
    {
        anim.Play("Wizard1P2AttackPlantToPlayer");
    }
}
