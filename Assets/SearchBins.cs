using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SearchBins : MonoBehaviour
{
    TMP_InputField input;
    BinScript[] bins = new BinScript[] { };

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<TMP_InputField>();
        bins = FindObjectsOfType<BinScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindBins(int binType)
    {
        FindBins((BinScript.BinType)binType);
    }
    public void FindBins(BinScript.BinType binType)
    {
        Vector3 floorPosition = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);
        float minSqrDist = float.MaxValue;
        int j= -1;
        for(int i = 0; i < bins.Length; i++)
        {
            if (bins[i].binType == binType)
            {
                float sqrDist = (floorPosition - bins[i].transform.position).sqrMagnitude;
                if ( sqrDist < minSqrDist)
                {
                    minSqrDist = sqrDist;
                    j = i;
                }
                
            }
        }
        for (int i = 0; i < bins.Length; i++)
        {
            SpriteRenderer sp = bins[i].pin;
            sp.color = i == j ? Color.green : new Color(0, 114 / 255f, 1);
        }
    }

}
