using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessLogin : MonoBehaviour
{
    private static ProcessLogin _instance;
    public static ProcessLogin Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("fuckign kill me now");
                throw new MissingReferenceException();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public const string DATA_URL_LOGIN = "http://localhost:81/login.php";

    public void Request(string username, string password, Action<int> onComplete = null)
    {
        StartCoroutine(ProcessRequest(username, password, onComplete));
    }

    IEnumerator ProcessRequest(string username, string password, Action<int> onComplete = null)
    {
        Debug.Log(string.Format("Processing request() with {0}, {1}", username, password));
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        WWW request = new WWW(DATA_URL_LOGIN, form);

        yield return request;

        if (string.IsNullOrEmpty(request.error))
        {
            //0 == login success
            //1 ==  invalid user/pass
            //-1 == server offline
            Debug.Log(request.text);
            int requestCode;
            bool validRequest = int.TryParse(request.text, out requestCode);

            if (validRequest == false)
            {
                requestCode = 4;
            }

            //here for logging purposes, dlt later better performance
            switch (requestCode)
            {
                case 0:
                    Debug.Log("Login successful");
                    break;
                case 1:
                    Debug.Log("Invalid username/password. Please try again.");
                    break;
                default:
                    Debug.Log("Server offline");
                    break;
            }

            if (onComplete != null)
            {
                onComplete(requestCode);
            }
        }
    }

}

