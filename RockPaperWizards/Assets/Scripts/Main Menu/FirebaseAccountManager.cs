using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;

public class FirebaseAccountManager : MonoBehaviour
{
    FirebaseAuth auth;
    public Text infoText;
    public InputField emailField;
    public InputField passwordField;

    string email, password;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;
        });
    }

    private void RegisterNewUser(string email, string password)
    {
        Debug.Log("Starting Registration");
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User Registerd: {0} ({1})", newUser.DisplayName, newUser.UserId);
            }
        });
    }

    private void SignIn(string email, string password)
    {

        if (GameData.Instance.gameData != null)
        {
            GameData.Instance.gameData = null;
            GameData.Instance.gameData = new GameInfo();
        }
        if (GameData.Instance.userGameData != null)
        {
            GameData.Instance.userGameData = null;
            GameData.Instance.userGameData = new PlayerInGameData();
        }

        if (GameData.Instance.playerLocalData != null)
        {
            GameData.Instance.playerLocalData = null;
            GameData.Instance.playerLocalData = new PlayerInfo();
        }

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);


                Debug.Log("Befor OnsignIn");

                GameData.Instance.OnSignIn(newUser.UserId);
            }
        });
    }

    // The following functions are called from Main Menu´s buttons.

    public void EnterNewUser()
    {
        email = emailField.text;
        password = passwordField.text;

        RegisterNewUser(email, password);
        SignIn(email, password);
    }
    public void RunSignIn()
    {
        email = emailField.text;
        password = passwordField.text;

        SignIn(email, password);
    }

    public void SignOut()
    {
        GameData.Instance.playerLocalData = null;
        GameData.Instance.gameData = null;
        GameData.Instance.userGameData = null;
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
