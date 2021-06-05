using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    public InputField usernameInput, passwordInput;


    public void ConnectToServer()
    {
        Client.instance.ConnectToServer();
    }

    /*public void ProcessLogin()
    {
        //Client.Instance.Connect();


        LoginModel model = new LoginModel();
        model.Username = usernameInput.text.ToLower();
        model.Password = passwordInput.text;
        model.Login();
    }*/


}
