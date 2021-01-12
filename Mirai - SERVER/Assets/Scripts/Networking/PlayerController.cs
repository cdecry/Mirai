using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public static List<GameObject> players = new List<GameObject>();

    public static void SpawnPlayer(NetworkConnection netConn)
    {
        GameObject player = Instantiate(NetworkManager.Instance.playerPrefab) as GameObject;
        //player.transform.position = new Vector2(Random.Range(-3, 4), Random.Range(-2, 2));
        player.transform.position = new Vector2(-1, -3);
        NetworkManager.Instance.playerPrefab.transform.position = player.transform.position;
        NetworkServer.AddPlayerForConnection(netConn, player, 0);
        players.Add(player);

        MovePlayer user = new MovePlayer
        {
            connectionID = netConn.connectionId,
            playerPosition = player.transform.position,
        };

        user.UpdatePlayerPosition();
    }

    public static void MovePlayer(NetworkConnection netConn, string keyCode)
    {
        var index = players.FindIndex(user => user.GetComponent<NetworkIdentity>().connectionToClient == netConn);
        GameObject player = players[index];
        var _rigidbody = player.GetComponent<Rigidbody2D>();
        //Vector2 pos = _rigidbody.transform.position;

        switch (keyCode)
        {
            case "right":
                //Vector2 pos = _rigidbody.transform.position;
                //Vector2 move = new Vector2(1, 0);
                //move = move.normalized * 3 * Time.deltaTime;
                //_rigidbody.MovePosition(pos + move);
                _rigidbody.position += Vector2.right * 3 * Time.deltaTime;
                //_rigidbody.position += Vector2.right * 3 * Time.deltaTime;
                break;
            case "left":
                _rigidbody.position += Vector2.left * 3 * Time.deltaTime;
                break;
            case "up":
                _rigidbody.position += Vector2.up * 3 * Time.deltaTime;
                break;
            case "down":
                _rigidbody.position += Vector2.down * 3 * Time.deltaTime;
                break;
            default:
                Debug.Log("defaulted cause u bad -.-");
                break;
        }

        NetworkServer.ReplacePlayerForConnection(netConn, player, 0);
        MovePlayer userMove = new MovePlayer
        {
            connectionID = netConn.connectionId,
            playerPosition = player.transform.position,
        };

        userMove.UpdatePlayerPosition();
    }

    

}
