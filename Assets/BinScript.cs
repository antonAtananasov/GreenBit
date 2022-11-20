using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public bool selectRandomType = true;
    GameObject[] bins = new GameObject[] { };
    public enum BinType
    {
        Paper,
        Plastic,
        Metal,
        Organic,
        Wood,
        Batteries,
        Cloth,
        Ewaste,
        Bulbs,
        Medicine,
        Petrol,
        Rubber,
        Monitor
    };
    public BinType binType;
    // Start is called before the first frame update
    void Start()
    {
        if (selectRandomType)
        {
            binType = (BinType)Random.Range(0,12);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
