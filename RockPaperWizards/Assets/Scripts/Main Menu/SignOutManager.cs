using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignOutManager : MonoBehaviour
{
    public void SignOut()
    {
        GameData.Instance.playerLocalData = null;
        GameData.Instance.gameData = null;
        GameData.Instance.userGameData = null;
        FirebaseAuth.DefaultInstance.SignOut();
        SceneController.Instance.LoadScene("SignInMenu");
        Debug.Log("User signed out");
    }
}
