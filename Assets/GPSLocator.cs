using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GPSLocator : MonoBehaviour
{
    public TMP_Text statusText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GPSLoc());
    }

    IEnumerator GPSLoc()
    {
        if (!Input.location.isEnabledByUser)
        {
            statusText.text = "Location not enabled by user";
            yield break;
        }

        statusText.text = "Starting service";
        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            statusText.text = "Timeout";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            statusText.text = "Connection failed";
            yield break;
        }
        else
        {
            //access granted
            InvokeRepeating("UpdateGPSData", .5f, 1f);
        }

    }

    void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            print(Input.location.lastData.longitude.ToString());
            print(Input.location.lastData.latitude.ToString());
        }
        else
        {

            //service stopped
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
