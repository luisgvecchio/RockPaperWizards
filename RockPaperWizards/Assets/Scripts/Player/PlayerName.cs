using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;
    GameObject labelHolderP1, labelHolderP2;

    void Start()
    {
        if(gameObject.name == "Player1")
        {
            nameLabel.text = PlayerPrefs.GetString("Player1Name");
            Transform canvas = GameObject.Find("Canvas").transform;
            labelHolderP1 = Instantiate(nameLabel.gameObject, canvas);
            labelHolderP1.GetComponent<RectTransform>().transform.position = transform.position + new Vector3(0, 3, -transform.position.z);
        }
        else if (gameObject.name == "Player2")
        {
            nameLabel.text = PlayerPrefs.GetString("Player2Name");
            Transform canvas = GameObject.Find("Canvas").transform;
            labelHolderP2 = Instantiate(nameLabel.gameObject, canvas);
            labelHolderP2.GetComponent<RectTransform>().transform.position = transform.position + new Vector3(0, 3, -transform.position.z);
        }

    }

    void Update()
    {
    }
}
