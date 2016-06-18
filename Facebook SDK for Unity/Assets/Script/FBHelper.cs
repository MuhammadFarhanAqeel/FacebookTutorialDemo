using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.UI;

public class FBHelper : MonoBehaviour {

    public Text usernameText;
    void Awake() {
        FB.Init(SetInit, OnhideUnity);
    }


    void SetInit() {

        if (FB.IsLoggedIn) {
            Debug.Log(" Facebook is Logged In");
        } else {
            Debug.Log(" Facebook is not logged in");
        }
    }


    void OnhideUnity(bool GameShown)
    {
        if (!GameShown) { Time.timeScale = 0; }
        else
        {
            Time.timeScale = 1;
        }
    }


    public void FBLogin() {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");
        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }

    void AuthCallBack(IResult result) {
        if (result.Error != null) {
            Debug.Log("problem with log in");
        } else {
            if (FB.IsLoggedIn)
            {
                Debug.Log("Facebook has successfully logged in!");
            }
            else {
                Debug.Log("FB is not logged in");
            }
        }
    }

    public void getUserName() {
        FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
    }

    void DisplayUsername( IResult result) {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else {
            usernameText.text = "Hi there" + result.ResultDictionary["first_name"];
        }
    }
}
