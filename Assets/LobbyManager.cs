using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Unity.VisualScripting.Antlr3.Runtime;
using TMPro;

public class LobbyManager : Photon.Pun.MonoBehaviourPunCallbacks
{
    [SerializeField] private int maximumPlayers;
    [SerializeField] private bool isVisible = true;
    [SerializeField] private bool isOpen = true;
    
    #region singleton
    public static LobbyManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    #region PUN Callbacks
    private void JoinTheLobby()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to Server.");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Join to lobby Done");
    }

    public void CreateRoom(string RoomName)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = isOpen;
        roomOptions.IsVisible = isVisible;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(RoomName, roomOptions);
       // PhotonNetwork.CreateRoom("RoomName");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"returnCode{returnCode}, Show messaage{message}.");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Welcom in the Room");
    }

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        Debug.Log($"Room list Count = {RoomList.Count} ");
    }
    #endregion

    


}


