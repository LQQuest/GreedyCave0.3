using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSpawn : MonoBehaviour
{
    public LayerMask whatIsRoom;
     

    public GameObject BottomClose;
    public GameObject TopClose;

    public float MoveAmount;
    public float MoveToPoint;

    
    void Update()
    {
        if (SpawnRooms.stopSpawnRoom == true ){
            Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,0.5f, whatIsRoom);

            if (roomDetection.GetComponent<RoomType>().type == 1)
            {
                Vector2 newPos = new Vector2(transform.position.x,transform.position.y - MoveAmount);
                Collider2D secondRoom = Physics2D.OverlapCircle(newPos, 0.5f, whatIsRoom);
                if (secondRoom.GetComponent<RoomType>().type == 0 || secondRoom.GetComponent<RoomType>().type == 1)
                {
                    Vector2 newPoss = new Vector2(transform.position.x, transform.position.y - MoveToPoint);
                    // transform.position = newPoss;
                    Instantiate(BottomClose, newPoss, Quaternion.identity);
                    Destroy(gameObject);
                }
                else Destroy(gameObject);
            } else if(roomDetection.GetComponent<RoomType>().type == 2 )
            {
                Vector2 newPos = new Vector2(transform.position.x,transform.position.y + MoveAmount);
                Collider2D secondRoom = Physics2D.OverlapCircle(newPos, 0.5f, whatIsRoom);
                if (secondRoom.GetComponent<RoomType>().type == 0 || secondRoom.GetComponent<RoomType>().type == 2)
                {
                    Vector2 newPoss = new Vector2(transform.position.x, transform.position.y + MoveToPoint);
                    Instantiate(TopClose, newPoss, Quaternion.identity);
                    Destroy(gameObject);
                }
                else Destroy(gameObject);
            } else if(roomDetection.GetComponent<RoomType>().type == 0)
            {
                Destroy(gameObject);
            }else if (roomDetection.GetComponent<RoomType>().type == 3)
            {
                Vector2 newPos = new Vector2(transform.position.x,transform.position.y - MoveAmount);
                Collider2D secondRoom = Physics2D.OverlapCircle(newPos, 0.5f, whatIsRoom);
                if (secondRoom.GetComponent<RoomType>().type == 0 || secondRoom.GetComponent<RoomType>().type == 1)
                {
                    Vector2 newPoss = new Vector2(transform.position.x, transform.position.y - MoveToPoint);
                    Instantiate(BottomClose, newPoss, Quaternion.identity);
                }
                Vector2 newPosv = new Vector2(transform.position.x,transform.position.y + MoveAmount);
                Collider2D thirdRoom = Physics2D.OverlapCircle(newPosv, 0.5f, whatIsRoom);
                if (thirdRoom.GetComponent<RoomType>().type == 0 || thirdRoom.GetComponent<RoomType>().type == 2)
                {
                    Vector2 newPossv = new Vector2(transform.position.x, transform.position.y + MoveToPoint);
                    Instantiate(TopClose, newPossv, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            PlayerController.gameOver = false;
        }
    }
}
