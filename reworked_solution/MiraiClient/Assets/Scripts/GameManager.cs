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
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation, List<int> _ids)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
            DontDestroyOnLoad(localPlayerPrefab);

            /*_player.GetComponent<PlayerManager>().id = _id;
            _player.GetComponent<PlayerManager>().username = _username;
            players.Add(_id, _player.GetComponent<PlayerManager>());*/
        }
        else
        {
            /*
            foreach (int _spawnId in _ids)
            {
                if (_id == _spawnId)
                {
                    _player = Instantiate(playerPrefab, _position, _rotation);


                    _player.GetComponent<PlayerManager>().id = _id;
                    _player.GetComponent<PlayerManager>().username = _username;
                    if (players.ContainsKey())
                    players.Add(_id, _player.GetComponent<PlayerManager>());
                }
            }*/

            
            _player = Instantiate(playerPrefab, _position, _rotation);
        }
        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        _player.GetComponent<PlayerManager>().location = "Shady";
        players.Add(_id, _player.GetComponent<PlayerManager>());


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