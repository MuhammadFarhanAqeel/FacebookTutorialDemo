using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
public class FBHelper : MonoBehaviour {

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
}
