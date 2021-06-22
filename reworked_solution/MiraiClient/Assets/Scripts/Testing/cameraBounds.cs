using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBounds : MonoBehaviour
{

    private GameObject bounds;

    private void Awake()
    {
        bounds = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (this.tag == "leftBound")
        {
            Debug.Log("hit left border");
            cameraScroll.Instance.targetPos = new Vector3(GameManager.players[Client.instance.myId].transform.position.x, 0, -50);  // player's trasnform position!

            bounds.transform.position = new Vector3(bounds.transform.position.x - 4.86979166667f, 0, 0);
            this.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
            this.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);

            // code above maybe redundent, check

        }
        else if (this.tag == "rightBound")
        {
            Debug.Log("hit right border");
            cameraScroll.Instance.targetPos = new Vector3(GameManager.players[Client.instance.myId].transform.position.x, 0, -50);

            bounds.transform.position = new Vector3(bounds.transform.position.x + 4.86979166667f, 0, 0);
            this.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
            this.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f); //-25497.6
        }
        
    }
}
