using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float distanse;
    public LayerMask whatIsCollision;
    public static bool deathTriiger = false;
    public GameObject deathAnim;

    private bool movingRight = true;

    public Transform collisionDetection;
    void Update()
    {
        if (deathTriiger == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);  
            RaycastHit2D collisionInfo = Physics2D.Raycast(collisionDetection.position, Vector2.right, distanse, whatIsCollision);
            RaycastHit2D collisionBottom = Physics2D.Raycast(collisionDetection.position, Vector2.down, distanse, whatIsCollision);

            // Debug.Log("Right "+ collisionInfo.collider);
            // Debug.Log("Down " + collisionBottom.collider);
            if(collisionInfo.collider == true || collisionBottom.collider == false)
            {
                if(movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0,-180,0);
                    movingRight = false;
                } else
                {
                    transform.eulerAngles = new Vector3(0,0,0);
                    movingRight = true;
                }
            }
        
        }else
        {
            Destroy(gameObject);
        }
         
    }
    private void OnDestroy() {
        Instantiate(deathAnim,new Vector2(transform.position.x, transform.position.y - 0.02f), Quaternion.identity);
    }
}
