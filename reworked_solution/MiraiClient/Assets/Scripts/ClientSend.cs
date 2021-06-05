using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ClientSend : MonoBehaviour
{
    

    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.userInputField.text);

            SendTCPData(_packet);
        }
    }

    public static void PlayerMovement(bool[] _inputs)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);
            foreach (bool _input in _inputs)
            {
                _packet.Write(_input);
            }
            _packet.Write(GameManager.players[Client.instance.myId].transform.rotation);

            SendUDPData(_packet);
        }
    }

    public static void LoginRequest()
    {
        string password = Encryptor.Encrypt(UIManager.instance.passInputField.text);

        using (Packet _packet = new Packet((int)ClientPackets.loginRequest))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.userInputField.text);
            _packet.Write(password);

            SendTCPData(_packet);
        }
    }

    public static void RemovePlayer()
    {
        string user = "";

    var search = GameManager.players.Where(p => p.Key == Client.instance.myId);

        foreach (var result in search)
        {
            user = result.Value.username;

        }

        using (Packet _packet = new Packet((int)ClientPackets.removePlayer))
        {

            _packet.Write(Client.instance.myId);
            _packet.Write(user);

            SendTCPData(_packet);
        }
    }

    public static void ChangeRoomRequest(string _room)
    {
        using (Packet _packet = new Packet((int)ClientPackets.changeRoomRequest))
        {
            _packet.Write(_room);

            SendTCPData(_packet);
        }
    }
    #endregion
}