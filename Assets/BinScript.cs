using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public bool selectRandomType = true;
    GameObject[] bins = new GameObject[] { };
    public Sprite[] icons;
    public SpriteRenderer spr, pin;
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
        Monitor,
        Glass
    };
    public BinType binType;
    // Start is called before the first frame update
    void Start()
    {
        if (selectRandomType)
        {
            binType = (BinType)Random.Range(0,12);
        }
        spr.sprite = icons[(int)binType];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    foreach (var bin in FindObjectsOfType<BinScript>())
                    {
                        bin.pin.color = new Color(0, 114 / 255f, 1);
                    }
                    raycastHit.transform.root.GetComponent<BinScript>().pin.color = Color.green;
                    //print(raycastHit.transform.name);
                }
            }
        }


    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }

}
