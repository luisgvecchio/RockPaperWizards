using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;

public class FirebaseAccountManager : MonoBehaviour
{
    FirebaseAuth auth;
    FirebaseDatabase db;
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
            db = FirebaseDatabase.DefaultInstance;

            db.RootReference.Child("Users").SetValueAsync("users");
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
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
