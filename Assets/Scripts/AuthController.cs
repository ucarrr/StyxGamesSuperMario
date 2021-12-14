using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;


public class AuthController : MonoBehaviour
{
    public Text emailInput, passwordInput;


    public void Login()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(
            emailInput.text, passwordInput.text).ContinueWith((
                task =>
                {
                    if (task.IsCanceled)
                    {
                        Firebase.FirebaseException e = task.Exception.Flatten().InnerException as Firebase.FirebaseException;
                        GetErrorMessage((AuthError)e.ErrorCode);
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Firebase.FirebaseException e = task.Exception.Flatten().InnerException as Firebase.FirebaseException;
                        GetErrorMessage((AuthError)e.ErrorCode);
                        return;


                    }
                    if (task.IsCompleted)
                    {
                        print("User is logged in");
                        SceneManager.LoadScene("Main Menu");

                    }
                }
            ));

    }
    public void RegisterUser()
    {

        if (emailInput.text.Equals("") && passwordInput.text.Equals(""))
        {
            print("Please enter an email and password to register");
            return;
        }

        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(emailInput.text, passwordInput.text).ContinueWith((task =>
        {
            if (task.IsCanceled)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerException as Firebase.FirebaseException;
                GetErrorMessage((AuthError)e.ErrorCode);
                return;

            }
            if (task.IsFaulted)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerException as Firebase.FirebaseException;
                GetErrorMessage((AuthError)e.ErrorCode);
                return;

            }
            if (task.IsCompleted)
            {
                print("Registration COMPLETE");

            }


        }));


    }

    public void Logout()
    {
        if(FirebaseAuth.DefaultInstance.CurrentUser != null){
            FirebaseAuth.DefaultInstance.SignOut();
        }

    }
    void GetErrorMessage(AuthError errorCode)
    {
        string mg = "";
        mg = errorCode.ToString();
        print(mg);
    }
}
