using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Invert()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
