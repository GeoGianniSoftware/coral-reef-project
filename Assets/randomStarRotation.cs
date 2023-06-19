using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomStarRotation : MonoBehaviour
{
    public bool rescale = false;
    public List<GameObject> feet = new List<GameObject>();

    public Gradient starBaseColor;
    // Start is called before the first frame update
    void Start()
    {
        Material m = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
        m.color = starBaseColor.Evaluate(Random.Range(0.0f, 1.0f));
        transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = m;
        foreach (GameObject g in feet) {
            g.transform.Rotate(transform.forward, Random.Range(-60.0f, 60.0f));
        }
        if(rescale)
        transform.localScale = Vector3.one * (Random.Range(.5f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
