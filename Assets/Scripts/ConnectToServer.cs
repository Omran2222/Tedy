using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_InputField UsernameInput;
    public TextMeshProUGUI ButtonText;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
       
    }

    public void OnClickConnect()
    {
        if(UsernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = UsernameInput.text;
            ButtonText.text = "Connecting...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

     public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Loading");
    }

}
