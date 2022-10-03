using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Unity.VisualScripting.Antlr3.Runtime;
using TMPro;
using UnityEditor;
using System.Runtime.CompilerServices;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    GameObject MainMenuButtons;
    GameObject LoadingPanel;
    GameObject CreateRoomPanel;
    public GameObject LobbyPanel;
    public GameObject RoomPanel;
    GameObject ErrorPanel;
    GameObject FindRoomPanel;
    public TMP_InputField RoomInputField;
    TextMeshProUGUI LoadingText;
    public TextMeshProUGUI RoomNameText;
    TextMeshProUGUI CreateRoomNameInputText;
    TextMeshProUGUI ErrorText;
    [SerializeField] private int maximumPlayers;
    [SerializeField] private bool isVisible = true;
    [SerializeField] private bool isOpen = true;
    private string[] FirstName = { "Omran", "Mike", "Moath", "Dived", "Jehad", "Jesse", };
    private string[] SecondName = { "Omr", "John", "Adam", "Alberto", "Karl" };
    private string[] LastName = { "Tesla", "Ricardo", "Newton", "Alsaedi", "Mero" };

    public RoomItem RoomItemPrefab;
    List<RoomItem> RoomItemsList;
    public Transform ContentObjerct;
#region singleton
public static LobbyManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
   
     void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
    }
    #region PUN Callbacks
    public void OnCreateRoom(string RoomName)
    {
        if(RoomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(RoomInputField.text, new RoomOptions(){MaxPlayers = 10});
        }
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = isOpen;
        roomOptions.IsVisible = isVisible;
        roomOptions.MaxPlayers = 20;
       // PhotonNetwork.CreateRoom(RoomName, roomOptions);
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
        LobbyPanel.SetActive(false);
        RoomPanel.SetActive(true);
        RoomNameText.text = "Room Name" + PhotonNetwork.CurrentRoom.Name;
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
        UpdateRoomList(RoomList);
    }

    void UpdateRoomList(List<RoomInfo> RooList)
    {
        foreach (RoomItem item in RoomItemsList)
        {
            Destroy(item.gameObject);
        }

        RoomItemsList.Clear();

        foreach(RoomInfo room in RooList)
        {
            RoomItem NewRoom = Instantiate(RoomItemPrefab);
            NewRoom.SetRoomName(room.Name);
            RoomItemsList.Add(NewRoom);
        }
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


