using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
   public TextMeshProUGUI RoomName;

   public void SetRoomName(string Room_Name)
   {
      RoomName.text = Room_Name;
   }
}
