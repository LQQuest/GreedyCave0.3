using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeroPosition : MonoBehaviour
{
    public Transform[] startingPositions;
    // public GameObject hero;


    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        
    }

    
}
