using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static IAnimationService animationServiceP1;
    private static IAnimationService animationServiceP2;

    public static IAnimationService GetAnimationProviderP1()
    {
        return animationServiceP1;
    }
    public static IAnimationService GetAnimationProviderP2()
    {
        return animationServiceP2;
    }

    public static void SetAnimationProviderP1(IAnimationService newService)
    {
        if (animationServiceP1 != null)
        {
            animationServiceP1.Unitialize();
        }

        animationServiceP1 = newService;
        animationServiceP1.Initialize();
    }

    public static void SetAnimationProviderP2(IAnimationService newService)
    {
        if (animationServiceP2 != null)
        {
            animationServiceP2.Unitialize();
        }

        animationServiceP2 = newService;
        animationServiceP2.Initialize();
    }
}
