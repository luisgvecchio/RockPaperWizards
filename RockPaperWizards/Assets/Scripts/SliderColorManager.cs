using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColorManager : MonoBehaviour
{
	public Slider slider; //Connect with slider
	public SpriteRenderer player; //Connect with player preview

    public void Start()
    {
        LoadColor(); //Load the starting color

        //Listen to slider changes
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void LoadColor()
    {
        //load saved value
        slider.value = PlayerPrefs.GetFloat("COLOR_NAME_KEY");

        player.color = Color.HSVToRGB(slider.value, 0.85f, 0.85f); //Update art color
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        //Update player/car color
        player.color = Color.HSVToRGB(slider.value, 0.85f, 0.85f);

        //We changed color again quickly, abort save.
        CancelInvoke(nameof(SaveValue));

        //Save after one second of no new value
        Invoke(nameof(SaveValue), 0.2f);
    }

    void SaveValue()
    {
        PlayerPrefs.SetFloat("COLOR_NAME_KEY", slider.value); //Save to player prefs
    }
}
