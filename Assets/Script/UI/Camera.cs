using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    

    
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x + 0.16f*2f, target.transform.position.y + 0.16f*1f, -1);
    }
}
