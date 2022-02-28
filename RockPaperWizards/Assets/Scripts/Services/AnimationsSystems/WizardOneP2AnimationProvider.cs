using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardOneP2AnimationProvider : IAnimationService
{
    Animator anim;

    public void Initialize()
    {
        anim = GameObject.FindGameObjectWithTag("P2Holder").GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Wizard1P2/Wizard1P2");
    }

    public void Unitialize()
    {
        anim = GameObject.FindGameObjectWithTag("P2Holder").GetComponent<Animator>();
        anim.runtimeAnimatorController = null;
    }

    public void PlayIdleAnimation()
    {
        anim.Play("Wizard1IdleP2");
    }
    public void PlayAttackMiddleWaterAnimation()
    {
        anim.Play("Wizard1P1AttackWaterMiddle");        
    }
    public void PlayAttackMiddleFireAnimation()
    {
        anim.Play("Wizard1P1AttackFireMiddle");
    }
    public void PlayAttackMiddlePlantAnimation()
    {
        anim.Play("Wizard1P1AttackPlantMiddle");
    }
    public void PlayAttackToPlayerWaterAnimation()
    {
        anim.Play("Wizard1P1AttackWaterToPlayer");
    }
    public void PlayAttacktoPlayerFireAnimation()
    {
        anim.Play("Wizard1P1AttackFireToPlayer");
    }
    public void PlayAttacktoPlayerPlantAnimation()
    {
        anim.Play("Wizard1P1AttackPlantToPlayer");
    }
}
