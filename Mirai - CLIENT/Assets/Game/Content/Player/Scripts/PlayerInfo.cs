using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
public class PlayerInfo : MonoSingleton<PlayerInfo>
{
    protected override void Init()
    {
        base.Init();

        DontDestroyOnLoad(this.gameObject);
    }

    public GameObject playerPrefab;
    public string PlayerName { get; set; }
    public string ipAddress;
    public Vector2 playerPos;
    public string playerLocation;

    //input manager later


}
