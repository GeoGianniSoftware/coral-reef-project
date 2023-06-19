using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingOcean : MonoBehaviour
{
    public float tileSpeed;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += new Vector2(1, 1)*Time.deltaTime*tileSpeed;
    }
}
