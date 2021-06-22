using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trying to go to Beach");
        ClientSend.ChangeRoomRequest("Beach"); // get string from gameobj name (is a img rn) to avoid hardcoding
    }

}
