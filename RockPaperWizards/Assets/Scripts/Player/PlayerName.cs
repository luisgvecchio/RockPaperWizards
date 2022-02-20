using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;
    GameObject labelHolder;

    public string player1Name;
    public string player2Name;

    Vector3 offset;

    private void Awake()
    {
        player1Name = GameData.Instance.gameData.players[0].name;
        player2Name = GameData.Instance.gameData.players[1].name;
    }
    void Start()
    {
        offset  = new Vector3(0, 100, -transform.position.z);

        if (gameObject.name == "Player1")
        {
            nameLabel.text = player1Name;
            SetPosition();
        }
        else if (gameObject.name == "Player2")
        {
            nameLabel.text = player2Name;
            SetPosition();
        }
    }

    private void SetPosition()
    {
        CreateLabelHolderAsChildOfCanvas();
        Vector3 anchoredPosition = ConvertWorldToUIPosition();
        SetUIPositionPlusOffset(anchoredPosition);
    }

    private void SetUIPositionPlusOffset(Vector3 anchoredPosition)
    {
        labelHolder.GetComponent<RectTransform>().transform.position = anchoredPosition + offset;
    }

    private Vector3 ConvertWorldToUIPosition()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        Vector3 anchoredPosition = transform.InverseTransformPoint(screenPoint);
        return anchoredPosition;
    }

    private void CreateLabelHolderAsChildOfCanvas()
    {
        Transform canvas = GameObject.Find("Canvas").transform;

        labelHolder = Instantiate(nameLabel.gameObject, canvas);
    }
}
