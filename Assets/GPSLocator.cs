using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Android;
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
        if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
            Permission.RequestUserPermission(Permission.CoarseLocation);
        if (Permission.HasUserAuthorizedPermission(Permission.CoarseLocation) && !Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            Permission.RequestUserPermission(Permission.FineLocation);

        yield return new WaitForSeconds(5);
        if (!Input.location.isEnabledByUser)
        {
            if (statusText != null)
                statusText.text = "Location not enabled by user";
            yield break;
        }

        if (statusText != null)
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
            if (statusText != null)
                statusText.text = "Timeout";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            if (statusText != null)
                statusText.text = "Connection failed";
            yield break;
        }
        else
        {
            if (statusText != null)
                statusText.text = "Initialization done";
            //access granted
            InvokeRepeating("UpdateGPSData", .5f, 1f);
        }

    }

    void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            if (statusText != null)
                statusText.text = Input.location.lastData.longitude.ToString() + "   " + Input.location.lastData.latitude.ToString();
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
