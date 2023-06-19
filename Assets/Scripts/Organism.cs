using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Organism
{
    public int ID;
    public string Name;
    public string Desc;
    public string Scientific;
    public string Slug;

    public Organism() {
        ID = -1;
    }
}
