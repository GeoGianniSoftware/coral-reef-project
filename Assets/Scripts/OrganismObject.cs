using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class OrganismObject : MonoBehaviour
{
    public int ID;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            FindObjectOfType<JSONReader>().SelectOrganism(ID);
            print("Selected " + FindObjectOfType<JSONReader>().selectedOrganism.Name);
        }
    }
}