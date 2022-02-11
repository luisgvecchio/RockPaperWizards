using System.Collections;
using System.Collections.Generic;

public interface IAnimationService : IService
{
    void PlayWinAnimation();

    void PlayLoseAnimation();

    void PlayIdleAnimation();

    void PlayAttackAnimation();
    
}
