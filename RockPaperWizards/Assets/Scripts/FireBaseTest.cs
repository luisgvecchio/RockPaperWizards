using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;

public class FireBaseTest : MonoBehaviour
{
    FirebaseAuth auth;
    FirebaseDatabase db;
    public Text infoText;
    public InputField emailField;
    public InputField passwordField;

    string emailRegister, passwordRegister;
    string emailSignIn, passwordSignIn;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;

            db = FirebaseDatabase.DefaultInstance;
            db.RootReference.Child("Users").SetValueAsync("users");
            //RegisterNewUser("test1@test.test", "Test123!");
            //RegisterNewUser("test2@test.test", "Test123!");
            //RegisterNewUser("test3@test.test", "Test123!");
            //RegisterNewUser("test4@test.test", "Test123!");
        });
    }

    public void SignInTestUser(string email = "carlos@test.test")
    {
        SignIn(email, "Test123!");

        Debug.Log("SignedIn");
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
                Debug.LogFormat("User Registerd: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);
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
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);
                infoText.text = newUser.Email;
                DataTest(auth.CurrentUser.UserId, Random.Range(0, 100).ToString());
            }
        });
    }
    public void EnterNewUser()
    {
        emailRegister = emailField.text;
        passwordRegister = passwordField.text;

        RegisterNewUser(emailRegister, passwordRegister);
    }

    public void RunSignIn()
    {
        emailSignIn = emailField.text;
        passwordSignIn = passwordField.text;

        SignIn(emailSignIn, passwordSignIn);
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SignOut();
    }

    private void SignOut()
    {
        auth.SignOut();
        Debug.Log("User signed out");
    }

    private void AnonymousSignIn()
    {
        auth.SignInAnonymouslyAsync().ContinueWith(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
            }
        });
    }

    private void DataTest(string userID, string data)
    {
        Debug.Log("Trying to write data...");
        var db = FirebaseDatabase.DefaultInstance;
        db.RootReference.Child("users").Child(userID).SetValueAsync(data).ContinueWith(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);
            else
                Debug.Log("DataTestWrite: Complete");
        });
    }
}
