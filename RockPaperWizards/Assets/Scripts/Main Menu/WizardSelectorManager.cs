using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void SetMenuImage();

public class WizardSelectorManager : MonoBehaviour
{
    public Image menuImage;
    public Sprite[] wizardSprites;

    public int spriteNumber = 0;

    private void Start()
    {
        SpriteSelectorToUserData();
    }

    private void SetMenuImage()
    {
        menuImage.sprite = wizardSprites[spriteNumber];
    }

    public void SelectUp()
    {
        spriteNumber++;
        SpriteSelectorToUserData();
        if (spriteNumber > wizardSprites.Length - 1) spriteNumber = 0;
        SetMenuImage();
    }


    public void SelectDown()
    {
        spriteNumber--;
        SpriteSelectorToUserData();
        if (spriteNumber < 0) spriteNumber = wizardSprites.Length - 1;
        SetMenuImage();
    }
    private void SpriteSelectorToUserData()
    {
        GameData.Instance.userGameData.wizard = spriteNumber;
        GameData.Instance.SavePlayerLocalData();
    }
}
