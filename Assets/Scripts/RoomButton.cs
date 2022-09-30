using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomButton : MonoBehaviour
{
   
        [SerializeField] private RoomInfo roomInfo;
        [SerializeField] private TMP_Text roomName;
        public void SetRoomInfo(RoomInfo info)
        {
            roomInfo = info;
            roomName.text = info.Name;
        }
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(roomInfo.Name);
            LobbyManager.instance.OnCreateRoom("");
        }
    
}
