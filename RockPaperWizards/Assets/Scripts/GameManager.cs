using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WizardSelectorManager wizardSelector;

    void Start()
    {
        wizardSelector.OnWizardChange += ChangeWizardAnimationProvider;
        ServiceLocator.SetAnimationProvider(new WizardOneAnimationProvider());
    }

    private void ChangeWizardAnimationProvider()
    {
        if (wizardSelector.spriteNumber == 0)
        {
            ServiceLocator.SetAnimationProvider(new WizardOneAnimationProvider());
        }

        else if (wizardSelector.spriteNumber == 1)
        {
            ServiceLocator.SetAnimationProvider(new WizardTwoAnimationProvider());
        }

        else if (wizardSelector.spriteNumber == 2)
        {
            ServiceLocator.SetAnimationProvider(new WizardThreeAnimationProvider());
        }
    }
}
