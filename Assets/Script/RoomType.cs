using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
   public int type;

   public void RoomDestraction(){
      Destroy(gameObject);
   }

   void Update() {
      if (PauseMenu.restartTrigger == true)
      {
         // Debug.Log("Destroy " + gameObject);
         Destroy(gameObject);
         FinishRoom.finishGen = false;
      }
         
   }
}
