using System.Collections;
using System.Collections.Generic;

public interface IAnimationService : IService
{
    void PlayIdleAnimation();

    void PlayAttackMiddleWaterAnimation();
    void PlayAttackMiddleFireAnimation();
    void PlayAttackMiddlePlantAnimation();
    void PlayAttackToPlayerWaterAnimation();
    void PlayAttacktoPlayerFireAnimation();
    void PlayAttacktoPlayerPlantAnimation();


}
