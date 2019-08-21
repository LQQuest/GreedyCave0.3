using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRoom : MonoBehaviour
{
    public Transform[] finishPosition;
    public LayerMask whatIsRoom;
    public GameObject finRoom;
    public LevelGeneration levelGen;
    public static bool finishGen = false;

    
    void Update()
    {
        int randNum = Random.Range(0,finishPosition.Length);
        transform.position = finishPosition[randNum].position;
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);

        if (roomDetection == null && levelGen.stopGeneration == true){
            Instantiate(finRoom, transform.position, Quaternion.identity);
            Destroy(gameObject);
            finishGen = true;
        } 
    }
}
