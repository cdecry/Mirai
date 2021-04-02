using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoundController : MonoBehaviour
{

    private static BoundController _instance;
    public static BoundController Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new System.Exception();
            }
            return _instance;
        }
    }

    private bool camTrig = false;
    // attached to player prefab to detec trigger
    // rename to player controller and move movement script here in future !
    /*private void Awake()
    {
        DontDestroyOnLoad(this);
    }*/
    private void Update()
    {
        if (camTrig)
        {
            CameraController.CameraRight();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "User_Interface")
        {
            camTrig = true;
            Debug.Log("triggered camRight" + collider.name);
        }
        else if (collider.name =="SceneTransition")
        {
            SceneManager.LoadScene("BubbleTea");
            Debug.Log("changing room...");
            if (_instance == this)
            {
                ChangeRoom room = new ChangeRoom
                {
                    connectionID = Client.Instance.networkClient.connection.connectionId,
                    newLocation = "BubbleTea", //change this to var later
                };
                room.HandleTransition();
            }
            
        }
        
        
    }
}
