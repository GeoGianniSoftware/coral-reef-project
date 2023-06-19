using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public GameObject tailObj;
    public GameObject lowerBodyObj;
    public GameObject headObj;
    float headRot = 0;
    public float maxHeadAngle = 15f;


    public float speed = 1;
    int dirH = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BodyLoop();
    }

    void BodyLoop() {

        float rand = Random.Range(0f, 1f);
        float finSpeed = speed;

        //Head
        if (Mathf.Abs(headObj.transform.localRotation.z * 100) > maxHeadAngle) {
            dirH = dirH * -1;
        }

        headRot = +(finSpeed * 3) * Time.deltaTime * dirH;

        headObj.transform.Rotate(Vector3.forward, headRot);
        lowerBodyObj.transform.Rotate(Vector3.forward, -headRot * .5f);
        tailObj.transform.Rotate(Vector3.forward, headRot*2f);


        //transform.position += Vector3.forward * -finSpeed * Time.deltaTime;


    }
}
