using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10f;
    public bool isMoving;
    // Update is called once per frame
    void Update()
    {
        if(!isMoving){ return; }
        transform.position += new Vector3(0,0,speed*Time.deltaTime); 
    }
}
