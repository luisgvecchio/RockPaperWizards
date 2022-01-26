using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutlineManager : MonoBehaviour
{
    SpriteRenderer sprite;
    public Material outline;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TurnOffOutline()
    {
        //sprite.material;
    }

    public void TurnOnOutline()
    {
        sprite.material = outline;
    }
}
