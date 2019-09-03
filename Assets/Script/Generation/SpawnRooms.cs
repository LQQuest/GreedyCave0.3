using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnRooms : MonoBehaviour
{
   public LayerMask whatIsRoom;
   public LevelGeneration levelGen;
   public static bool stopSpawnRoom = false;

   

    
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 0.5f, whatIsRoom);
        

        if (roomDetection == null && FinishRoom.finishGen == true )
        {
            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            Invoke("StopGen", 0.1f);
            
            // Destroy(gameObject);    
        }
    }
    void StopGen()
    {
        stopSpawnRoom = true;
    }
}
