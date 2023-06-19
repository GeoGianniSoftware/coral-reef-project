using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolWander : MonoBehaviour
{
    public bool rescale = false;
    public List<SchoolWander> otherFish;
    public int speciesID;
    public float maxSpeed = 20;
    float Speed = 20;
    float mod = 1;
    public float Range = 10;
    public float rotSpeed;
    

    public float minHeight = 1;
    public float maxHeight = 4;



    Vector3 spawnPos;
    Vector3 wayPoint;
    Vector3 origin;


    private Vector3 GetMeanVector() {
        if (otherFish.Count == 0)
            return Vector3.zero;

        float x = 0f;
        float y = 0f;
        float z = 0f;

        foreach (SchoolWander pos in otherFish) {
            x += pos.transform.position.x;
            y += pos.transform.position.y;
            z += pos.transform.position.z;
        }
        return new Vector3(x / otherFish.Count, y / otherFish.Count, z / otherFish.Count);
    }

    void Start() {
        spawnPos = transform.position;
        rotSpeed *= (Random.Range(0.8f, 1f));
        //initialise the target way point
        origin = GetMeanVector();
        Wander(false);
        
        foreach(SchoolWander fish in FindObjectsOfType<SchoolWander>()) {
            if(fish.speciesID == speciesID) {
                otherFish.Add(fish);
            }
        }

        float spawnHeight = Random.Range(minHeight, maxHeight);
        float sizePercentage = spawnHeight / maxHeight;
        if (rescale) {
            transform.localScale = Vector3.one * (sizePercentage + .05f);

            transform.position = new Vector3(Random.Range(origin.x - Range, origin.x + Range), Random.Range(minHeight, maxHeight), Random.Range(origin.z - Range, origin.z + Range));
        }
        

    }

    void Update() {

        transform.position += transform.TransformDirection(Vector3.right) *mod * Speed * Time.deltaTime;
        Vector3.MoveTowards(transform.position, spawnPos, Speed);
        if ((transform.position - wayPoint).magnitude < 5 ||(Vector3.Distance(transform.position, origin) > Range)) {

            // when the distance between us and the target is less than 3
            // create a new way point target
            Wander((Vector3.Distance(transform.position, origin) > Range));
        }
        
    }

    void Wander(bool spawnoverride) {
        Speed = Random.Range(maxSpeed * .5f, maxSpeed);
        if (otherFish.Count == 0 || spawnoverride) {
            origin = new Vector3(Random.Range(spawnPos.x - Range, spawnPos.x + Range), transform.position.y, Random.Range(spawnPos.z - Range, spawnPos.z + Range));

        }
        else {
            int test = Random.Range(0, 10);
            if (test <= 3) {

                origin = -GetMeanVector() - transform.position;
                mod = 1f;

            }
            else if (test > 3 && test <= 5) {

                origin = spawnPos;
                //origin = new Vector3(Random.Range(spawnPos.x - Range, spawnPos.x + Range), Random.Range(minHeight, maxHeight), Random.Range(spawnPos.z - Range, spawnPos.z + Range));
                mod = 1f;

            }
            else {
                int randomCount = Random.Range(0, otherFish.Count - 1);
                origin = otherFish[randomCount].transform.position;
                mod = 1.5f;
            }
        }
       


        // does nothing except pick a new destination to go to

        wayPoint = new Vector3(Random.Range(origin.x - Range, origin.x + Range), transform.position.y, Random.Range(origin.z - Range, origin.z + Range));

        // don't need to change direction every frame seeing as you walk in a straight line only
        Quaternion rotation = Quaternion.LookRotation(wayPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);

    }



}
