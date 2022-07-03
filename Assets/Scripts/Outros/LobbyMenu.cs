using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class LobbyMenu : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI username;
    public TMP_InputField createRoom, joinRoom;
    void Start()
    {
#if UNITY_EDITOR
        username.text = $"Username: UNITY EDITOR";
#endif
        username.text = $"Username: {PlayerPrefs.GetString("UserName")}";

    }


    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoom.text);
    }
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoom.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
