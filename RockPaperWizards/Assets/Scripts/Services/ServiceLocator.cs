using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static IAnimationService animationService;

    public static IAnimationService GetAudioProvider()
    {
        return animationService;
    }

    public static void SetAnimationProvider(IAnimationService newService)
    {
        if (animationService != null)
        {
            animationService.Unitialize();
        }

        animationService = newService;
        animationService.Initialize();
    }
}
