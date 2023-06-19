using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFish : MonoBehaviour
{
    public bool rescale = false;
    public float moveTime = 2f;
    float t;

    public float Speed = 20;
    public float Range = 10;
    public float rotSpeed;

    public float minHeight = 1;
    public float maxHeight = 4;




    Vector3 wayPoint;
    Vector3 origin;

    void Start() {
        //initialise the target way point
        origin = transform.position;
        Wander();

        if(rescale)
        transform.position = new Vector3(Random.Range(origin.x - Range, origin.x + Range), Random.Range(minHeight, maxHeight), Random.Range(origin.z - Range, origin.z + Range));

    }

    void Update() {
        
        
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.TransformDirection(Vector3.right) * Speed * Time.deltaTime, moveTime);
            
        
        Vector3.MoveTowards(transform.position, origin, Speed);
        if ((transform.position - wayPoint).magnitude < 5 || Vector3.Distance(transform.position, origin) > Range) {
            // when the distance between us and the target is less than 3
            // create a new way point target
            Wander();


        }
    }

    void Wander() {
        // does nothing except pick a new destination to go to

        wayPoint = new Vector3(Random.Range(origin.x - Range, origin.x + Range), Random.Range(1.0f, maxHeight), Random.Range(origin.z - Range, origin.z + Range));

        // don't need to change direction every frame seeing as you walk in a straight line only
        Quaternion rotation = Quaternion.LookRotation(wayPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);

    }



}
