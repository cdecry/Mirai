using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject dummyPlayer;
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dummyPlayer.transform.position = new Vector3(0, 5, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dummyPlayer.transform.position = new Vector3(0, -5, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dummyPlayer.transform.position = new Vector3(-5, 0, 0);
            //cameraScroll.ScrollLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dummyPlayer.transform.position = new Vector3(5, 0, 0);
        }

        if (transform.position.x < -3 || transform.position.x > 3)
        {
            //cameraScroll.Instance.targetPos = transform.position;
        }

    }

}
