using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        sprite.color = sprite.color = Color.HSVToRGB(PlayerPrefs.GetFloat("COLOR_NAME_KEY"), 0.85f, 0.85f);
    }
}
