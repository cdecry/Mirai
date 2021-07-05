using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            // DontDestroyOnLoad(localPlayerPrefab);
            // DontDestroyOnLoad(playerPrefab);
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }


    /*
     * creating gameobject called _player
     * if client wants to spawn itself (own id), spawn itslef nd debug local player msg
     * if not, this means that client is asking to spawn another user (with _id), spawn user with that id and debug other player msg
     * add every player spawned into PlayerManager diciontary with gameobject and id
     */
    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation, string _room)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
            DontDestroyOnLoad(localPlayerPrefab);
            DontDestroyOnLoad(_player);
            Debug.Log($"GameManager.cs - SpawnPlayer(): local player spawned");
        }
        else
        {
            
            _player = Instantiate(playerPrefab, _position, _rotation);
            DontDestroyOnLoad(_player);
            Debug.Log($"GameManager.cs - SpawnPlayer(): one other player {_id} spawned");
        }
        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        _player.GetComponent<PlayerManager>().location = _room;
        players.Add(_id, _player.GetComponent<PlayerManager>());

        Debug.Log($"    Player name: {GameManager.players[_id].username}; Room: {GameManager.players[_id].location}");
        Debug.Log($"    Player pos: {GameManager.players[_id].transform.position}");
        /*for (int i = 1; i < GameManager.players.Count + 1; i++)
        {
            Debug.Log($"    Player name: {GameManager.players[i].name}; Room: {GameManager.players[i].location}");
        }*/

    }

    public void RemovePlayer(int _id)
    {
        Debug.Log("removeplayer in gamemanager.cs called");
        // add linq quick find
        foreach (KeyValuePair<int, PlayerManager> _player in players)
        {
            if (_id == _player.Value.id)
            {
                Debug.Log($"attempting to destroy player {_id}");
                //GameObject.Destroy(_player);
            }
        }

        //players.Add(_id, _player.GetComponent<PlayerManager>());
    }
}