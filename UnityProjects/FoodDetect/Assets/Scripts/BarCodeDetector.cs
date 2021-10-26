using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

using ZXing;

public class BarCodeDetector : MonoBehaviour
{
    string lastResult;
    PlacePane pp;

    // Start is called before the first frame update
    void Start()
    {
        pp = GameObject.Find("AR Session Origin").GetComponent<PlacePane>();
    }

    // Update is called once per frame
    void Update()
    {
        Texture2D screenshot = takeScreenshot();
        string result = getBarcodeValue(screenshot);

        if (result != null && !result.Equals(lastResult))
        {
            lastResult = result;
            string json = queryBarcode(result);

            BarcodeAPIResult res_json = parseJson(json);
            pp.placePane(res_json);
        }        

        Destroy(screenshot);
    }

    public Texture2D takeScreenshot()
    {
        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        return screenshot;
    }

    public string getBarcodeValue(Texture2D screenshot)
    {
        IBarcodeReader reader = new BarcodeReader();
        var barcodeBitmap = screenshot.GetPixels32();

        var result = reader.Decode(barcodeBitmap, screenshot.width, screenshot.height);

        if(result == null)
        {
            return null;
        }

        return result.ToString();
    }

    public string queryBarcode(string barcode)
    {
        string url = "https://world.openfoodfacts.org/api/v0/product/" + barcode + ".json";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        return jsonResponse;
    }

    public BarcodeAPIResult parseJson(string json)
    {
        BarcodeAPIResult myObject = JsonUtility.FromJson<BarcodeAPIResult>(json);
        return myObject;
    }
}
