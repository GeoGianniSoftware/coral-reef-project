using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeStar : MonoBehaviour
{
    public Gradient starBaseColor;
    public float random;
    public List<GameObject> feet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomize());
    }

    IEnumerator randomize() {
        foreach (GameObject foot in feet) {
            

            Vector3 randomize = new Vector3(Random.Range(-random, random), 0, Random.Range(-random, random));
            foot.transform.position += randomize;
            float footHeight = foot.transform.position.y;
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 8f)) {
                if(hit.point != null) {
                    footHeight = hit.point.y;
                    foot.transform.parent.gameObject.AddComponent<BoxCollider>();
                    foot.transform.parent.gameObject.GetComponent<BoxCollider>().size = Vector3.one * .25f;
                }
            }
            Vector3 footPos = foot.transform.position;
            footPos.y = footHeight;
            foot.transform.position = footPos;
            
        }
        float sizePercent = Random.Range(.45f, 1.0f);
        transform.localScale *= sizePercent;
        yield return new WaitForSeconds(.1f);
        
        foreach (GameObject foot in feet) {
            Destroy(foot);

        }
        Material m;
        if (feet.Count == 0) {
            m = transform.GetComponent<MeshRenderer>().material;
        }
        else {
            m = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
        }
        m.color = starBaseColor.Evaluate(Random.Range(0.0f, 1.0f));

        if (feet.Count == 0) {
            transform.GetComponent<MeshRenderer>().material = m;
        }
        else {
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = m;
        }



        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
