using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void SetMenuImage();

public class WizardSelectorManager : MonoBehaviour
{
    public Image menuImage;
    public Sprite[] wizardSprites;

    public int spriteNumber;

    public event SetMenuImage OnWizardChange;

    // Update is called once per frame

    private void SetMenuImage()
    {
        menuImage.sprite = wizardSprites[spriteNumber];

        OnWizardChange?.Invoke();
    }

    public void SelectUp()
    {
        spriteNumber++;
        if (spriteNumber > wizardSprites.Length - 1) spriteNumber = 0;
        SetMenuImage();
    }
    public void SelectDown()
    {
        spriteNumber--;
        if (spriteNumber < 0) spriteNumber = wizardSprites.Length - 1;
        SetMenuImage();
    }
}
