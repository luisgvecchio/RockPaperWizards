using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        float random = Random.Range(0, 0.7f);
        sprite.color = Color.HSVToRGB(random, 0.85f, 0.85f);
    }
}
