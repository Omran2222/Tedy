using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Unity.VisualScripting.Antlr3.Runtime;
using TMPro;
using UnityEditor;
using System.Runtime.CompilerServices;

public class LobbyManager : Photon.Pun.MonoBehaviourPunCallbacks
{
    GameObject MainMenuButtons;
    GameObject LoadingPanel;
    GameObject CreateRoomPanel;
    GameObject RoomPanel;
    GameObject ErrorPanel;
    GameObject FindRoomPanel;
    TextMeshProUGUI LoadingText;
    TextMeshProUGUI RoomNameText;
    TextMeshProUGUI CreateRoomNameInputText;
    TextMeshProUGUI ErrorText;
    [SerializeField] private int maximumPlayers;
    [SerializeField] private bool isVisible = true;
    [SerializeField] private bool isOpen = true;
    private string[] FirstName = { "Omran", "Mike", "Moath", "Dived", "Jehad", "Jesse", };
    private string[] SecondName = { "Omr", "John", "Adam", "Alberto", "Karl" };
    private string[] LastName = { "Tesla", "Ricardo", "Newton", "Alsaedi", "Mero" };

   
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
    public void OnCreateRoom(string RoomName)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = isOpen;
        roomOptions.IsVisible = isVisible;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(RoomName, roomOptions);
        // PhotonNetwork.CreateRoom("RoomName");
    }
    private void JoinTheLobby()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to Server.");
        JoinTheLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Join to lobby Done");
        OnCreateRoom(name);

        
    }

   

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"returnCode{returnCode} \n messaage: {message}");
    }

    public override void OnJoinedRoom()
    {
       /* Dictionary<string, List<string>> PlayersName = new Dictionary<string, List<string>>();

        foreach (var Player in PlayersName)
        {
            PlayersName.Add(Player, new List<string>());
        }
        Debug.Log("Welcom in the Room "+ FirstName[Random.Range(0, FirstName.Length)]+" " + SecondName[Random.Range(0, SecondName.Length)]+ " "  + LastName[Random.Range(0, LastName.Length)]);
       */
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        Debug.Log("You left the Room");
    }

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        Debug.Log($"Room list Count = {RoomList.Count} ");
    }

    
    
    #endregion
    /*
    #region Custom Methods
    public void CloseAllMenus()
    {

    }

    public void OpenMainMenuButtons()
    {

    }

    public void OpenLoadingPanel(string message)
    {

    }

    public void OpenRoomPanel()
    {

    }

    public void OpenErrorPanel(string message)
    {

    }

    public void OpenCreateRoomPanel()
    {

    }

    public void CreateRoom()
    {

    }



    #endregion

    */


}


