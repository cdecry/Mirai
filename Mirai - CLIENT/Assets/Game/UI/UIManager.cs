using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class UIManager : MonoSingleton<UIManager>
{
    protected override void Init()
    {
        base.Init();
    }

    public void Signout()
    {
        Debug.Log("Attempting to signout");
        ClientScene.RemovePlayer(0);
        SceneManager.LoadScene("Main_Menu");
    }
}
