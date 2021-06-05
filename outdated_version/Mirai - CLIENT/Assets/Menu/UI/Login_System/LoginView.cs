using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    public InputField usernameInput, passwordInput;

    public void ConnectToServer()
    {
        if (Client.Instance.networkClient.isConnected == false)
        {
            Client.Instance.Connect();
        }
        else
        {
            Debug.Log("attempting to login...");
        }

    }

    public void ProcessLogin()
    {
        //Client.Instance.Connect();


        LoginModel model = new LoginModel();
        model.Username = usernameInput.text.ToLower();
        model.Password = passwordInput.text;
        model.Login();
    }


}
