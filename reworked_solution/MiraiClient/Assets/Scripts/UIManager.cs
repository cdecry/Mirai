﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public const string DATA_URL_SIGNUP = "http://localhost:81/signup.php";
    public const string DATA_URL_CHECK_KEY = "http://localhost:81/checkkey.php";

    public string ipAddress;
    public Button loginSelect, registerSelect;

    public GameObject loginPanel, registerPanel;
    public InputField usernameLogin, passwordLogin;

    public InputField usernameRegister, passwordRegister, passwordVerification, email, pin, pinVerification;
    public Button registerButton;



    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }

        registerSelect.onClick.AddListener(OpenRegisterPanel);
        loginSelect.onClick.AddListener(OpenLoginPanel);
    }

    public void ConnectToServer()
    {
        Debug.Log("ConnectToServer() in UIManager.cs");
        loginPanel.SetActive(false);
        //userInputField.interactable = false;
        Client.instance.ConnectToServer();

        // is it this thing ??
        StartCoroutine(ConnectCoroutine());

        IEnumerator ConnectCoroutine()
        {
            yield return new WaitForSeconds(0.01f);
            ClientSend.LoginRequest();
        }

        
    }


    void OpenRegisterPanel()
    {
        usernameRegister.text = passwordRegister.text = passwordVerification.text = email.text = pin.text = pinVerification.text = "";
        registerPanel.SetActive(true);
        registerSelect.gameObject.SetActive(false);
        loginSelect.gameObject.SetActive(false);
    }

    void OpenLoginPanel()
    {
        usernameLogin.text = passwordLogin.text = "";
        loginPanel.SetActive(true);
        registerSelect.gameObject.SetActive(false);
        loginSelect.gameObject.SetActive(false);
    }

    #region Registeration

    public void RegisterComplete()
    {
        //make sure nothing blank
        if (usernameRegister.text == "" || passwordRegister.text == "" || passwordVerification.text == "" || email.text == "" || pin.text == "" || pinVerification.text == "")
        {
            return;
        }

        //check if password and pw verify match   remeber conv. ex int.Parse(age.text) for number

        if (passwordRegister.text != passwordVerification.text)
        {
            return;
        }
        if (pin.text != pinVerification.text)
        {
            return;
        }

        //ipAddress = IPManager.GetIP(ADDRESSFAM.IPv4);
        ipAddress = "test";

        //if all gud, send data to website
        Debug.Log("ProcessingRequest()");

        //hash pw


        //string newPw = passwordRegister.text;



        StartCoroutine(ProcessRequest(usernameRegister.text, Encryptor.Encrypt(passwordRegister.text), DATA_URL_SIGNUP, email.text, pin.text, ipAddress));
    }

    IEnumerator ProcessRequest(string username, string password, string url, string email, string pin, string ipaddress)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        form.AddField("email", email);
        form.AddField("pin", pin);
        form.AddField("ipaddress", ipaddress);

        WWW request = new WWW(url, form);

        yield return request;

        if (string.IsNullOrEmpty(request.error))
        {
            //0 == signup complete
            //1 == username taken
            //2 == login success
            //3 ==  invalid user/pass
            //4 == server offline
            Debug.Log(request.text);
            int requestCode;
            bool validRequest = int.TryParse(request.text, out requestCode);

            if (validRequest == false)
            {
                requestCode = 4;
                StopAllCoroutines();
            }

            switch (requestCode)
            {
                case 0:
                    Debug.Log("Signup Completed!");
                    registerPanel.SetActive(false);
                    loginPanel.SetActive(false);

                    registerSelect.gameObject.SetActive(true);
                    loginSelect.gameObject.SetActive(true);
                    break;
                case 1:
                    Debug.Log("Username already exists.");
                    break;
                case 2:
                    Debug.Log("Login successful");

                    //SceneManager.LoadScene("Main");
                    break;
                case 3:
                    Debug.Log("Invalid username/password. Please try again.");
                    break;
                case 4:
                    Debug.Log("Server offline");
                    break;
                case 5:
                    Debug.Log("Invalid Alphakey");
                    break;
            }
        }
    }

    #endregion

}