using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using ZXing;
public class QRScanner : MonoBehaviour
{
    public RawImage camTarget;
    public AspectRatioFitter aspectFitter;
    public RectTransform scanZone;
    WebCamTexture webCamTeture;
    public float scanSpeed = 1 / 4f;
    public TMP_Text outputText;
    public TMP_InputField inputField;
    public bool controlAspectRatio = false;
    // Start is called before the first frame update
    void Start()
    {
        InitializeCamera();
    }

    // Update is called once per frame
    float timer;
    void Update()
    {
        if (webCamTeture != null && timer >= scanSpeed)
        {
            ScanQR();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void InitializeCamera()
    {
        foreach (var camDevice in WebCamTexture.devices)
        {
            if (!camDevice.isFrontFacing)
            {
                webCamTeture = new WebCamTexture(camDevice.name, (int)scanZone.rect.width, (int)-scanZone.rect.height);
                break;
            }
        }
        if (webCamTeture == null) 
            foreach (var camDevice in WebCamTexture.devices)
            {
                webCamTeture = new WebCamTexture(camDevice.name, (int)scanZone.rect.width, (int)-scanZone.rect.height);
            }
        webCamTeture.Play();
        camTarget.texture = webCamTeture;
        if (controlAspectRatio)
            aspectFitter.aspectRatio = (float)webCamTeture.width / (float)webCamTeture.height;
    }

    public void ScanQR()
    {
        IBarcodeReader reader = new BarcodeReader();
        Result result = reader.Decode(webCamTeture.GetPixels32(), webCamTeture.width, webCamTeture.height);
        if (result != null)
        {

            if (inputField != null)
                inputField.text = result.Text;
            if (outputText != null)
                outputText.text = result.Text;
        }
    }

    public void RotateImageTarget()
    {
        camTarget.transform.Rotate(0, 0, 90);
    }
}
