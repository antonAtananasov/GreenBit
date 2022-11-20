using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class CreateQR : MonoBehaviour
{

    //Need to produce a string array of QR codes
    string[] QrCodeStr = { "https://www.baidu.com/", "https://www.cnblogs.com/Mr-Miracle/", "https://unity3d.com/cn", "https://www.sogou.com/" };
    //Display the QR code on the screen
    public RawImage image;
    //Store QR code
    Texture2D encoded;
    int Nmuber = 0;
    // Use this for initialization
    void Start()
    {

        encoded = new Texture2D(256, 256);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Btn_CreatQr();
            Nmuber++;
            if (Nmuber >= QrCodeStr.Length)
            {
                Nmuber = 0;
            }
        }
    }

    /// <summary>
    ///  Define method to generate QR code
    /// </summary>
    /// <param name="textForEncoding">Need to produce the string of QR code</param>
    /// <param name="width">width</param>
    /// <param name="height">high</param>
    /// <returns></returns>
    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }


    /// <summary>
    ///  Generate QR code
    /// </summary>
    public void Btn_CreatQr()
    {

        if (QrCodeStr[Nmuber].Length > 1)
        {
            //QR code write picture
            var color32 = Encode(QrCodeStr[Nmuber], encoded.width, encoded.height);
            encoded.SetPixels32(color32);
            encoded.Apply();
            //The generated QR code image is attached to RawImage
            image.texture = encoded;
        }
        else
        {
            GameObject.Find("Text_1").GetComponent<Text>().text = "No information is generated";
        }
    }
}