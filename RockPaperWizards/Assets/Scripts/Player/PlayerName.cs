using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;
    GameObject labelHolderP1, labelHolderP2;

    public string player1Name;
    public string player2Name;

    private void Awake()
    {
        player1Name = PlayerPrefs.GetString("Player1Name");
        player2Name = PlayerPrefs.GetString("Player2Name");
    }
    void Start()
    {


        if (gameObject.name == "Player1")
        {
            nameLabel.text = player1Name;
            Transform canvas = GameObject.Find("Canvas").transform;
            labelHolderP1 = Instantiate(nameLabel.gameObject, canvas);
            labelHolderP1.GetComponent<RectTransform>().transform.position = transform.position + new Vector3(0, 2, -transform.position.z);
        }
        else if (gameObject.name == "Player2")
        {
            nameLabel.text = player2Name;
            Transform canvas = GameObject.Find("Canvas").transform;
            labelHolderP2 = Instantiate(nameLabel.gameObject, canvas);
            labelHolderP2.GetComponent<RectTransform>().transform.position = transform.position + new Vector3(0, 2, -transform.position.z);
        }

    }
}
