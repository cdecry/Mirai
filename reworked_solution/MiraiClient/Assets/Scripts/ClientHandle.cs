using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    /*
     * creating a list of ids that need to be spawned
     * reading the sent id, usenrname, position, and id list
     * callig spawnplayer funcition with list of ids
     * 
     */
    public static void SpawnPlayer(Packet _packet)
    {

        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();
        string _room = _packet.ReadString();

        //!! add users to spawn, read lists  in packets
        //List _playersToSpawn = _packet.ReadList();
        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation, _room);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        float _flip = _packet.ReadFloat();
        Vector3 _targetPosition = _packet.ReadVector3();

        if (GameManager.players.ContainsKey(_id))
        {
            if (GameManager.players[_id] != null)
            {
                //GameManager.players[_id].transform.position = Vector3.MoveTowards(GameManager.players[_id].transform.position, _targetPosition, 7 * Time.deltaTime);
                GameManager.players[_id].transform.position = _position;
                GameManager.players[_id].transform.localScale = new Vector3(_flip, 1f, 1f);
            }
            //SceneManager.LoadScene("Shady");
        }
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();

        if (GameManager.players.ContainsKey(_id))
        {
            GameManager.players[_id].transform.rotation = _rotation;
        }
    }

    public static void LoginRequestReceived(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        int _requestCode = _packet.ReadInt();

        switch (_requestCode)
        {
            //login success
            case 0:
                Debug.Log("login successful! spawning player...");
                SceneManager.LoadScene("Shady");
                Debug.Log("loaded scene.");
                break;
            //invalid req for user/pass
            case 1:
                Debug.Log("Incorrect user/pass");
                Client.instance.Disconnect();
                //UIManager.instance.startMenu.SetActive(true);
                //disconnect
                break;
            default:
                Debug.Log("server offline" + _requestCode);
                //disconnect
                break;
        }
    }

    public static void RemovePlayerReceived(Packet _packet)
    {
        int _id = _packet.ReadInt();
        // linq thing faster
        foreach (GameObject _player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (_player.name == "Player(Clone)")
            {
                if (_player.GetComponent<PlayerManager>().id == _id)
                {
                    GameManager.players.Remove(_id);
                    GameObject.Destroy(_player);
                }
            }
        }

        Debug.Log($"ClientHandle.cs - RemovePlayerReceived(): Local Player removed specific player");

    }

    public static void RemovePlayers(Packet _packet)
    {
        int _id = _packet.ReadInt();
        // linq thing faster
        foreach (GameObject _player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (_player.name == "Player(Clone)")
            {
                GameManager.players.Remove(_player.GetComponent<PlayerManager>().id);
                GameObject.Destroy(_player);
            }
        }

        Debug.Log("ClientHandle.cs - RemovePlayers(): Local Player removed all players in room.");

    }

    public static void ChangeRoom(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _room = _packet.ReadString();
        // linq thing faster

        GameManager.players[_id].location = _room;
        SceneManager.LoadScene(_room);

        Debug.Log($"ClientHandle.cs - ChangeRoom(): Player {GameManager.players[_id].username} moved to room {_room} also:");
        /*for (int i = 1; i < GameManager.players.Count + 1; i++)
        {
            Debug.Log($"    Player name: {GameManager.players[i].username}; Room: {GameManager.players[i].location}");
        }*/
    }

    public static void ChangeClothes(Packet _packet)
    {
        int _id = _packet.ReadInt();
        List<int> _items = _packet.ReadListInt();

        Inventory.ChangeClothes(_id, _items);
        Debug.Log("client handling change clothes");
    }

    public static void SyncInventory(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _itemID = _packet.ReadInt();

        // inventory function
        //Inventory.AddItem(_itemID);
        Debug.Log("syncinvent itemid sent was " + _itemID);
        /*if (PlayerManager.inventory != null)
        {
            //PlayerManager.Added(_itemID, 1);
            Debug.Log("added");
        }
        else
        {
            Debug.Log("it was null");
        }*/
    }


    /*
    public static void AddItemToInventory(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _itemID = _packet.ReadInt();

        Client.AddItem(_itemID);
    }*/

}