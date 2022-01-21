using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;
    GameObject labelHolder;

    void Start()
    {
        nameLabel.text = PlayerPrefs.GetString("PlayerName");
        Transform canvas = GameObject.Find("Canvas").transform;
        labelHolder = Instantiate(nameLabel.gameObject, canvas);
    }

    void Update()
    {
        labelHolder.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }
}
