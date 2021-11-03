using System.IO;
using System.Net;
using UnityEngine;
using ZXing;

public class BarCodeDetector : MonoBehaviour
{
    // save last scan in order not no scan same barcode twice
    string lastResult;

    // script to create informational panel
    PlacePlane pp;

    // Start is called before the first frame update
    void Start()
    {
        pp = GameObject.Find("AR Session Origin").GetComponent<PlacePlane>();
    }

    // Update is called once per frame
    void Update()
    {
        // Takes screenshot to find barcode in
        Texture2D screenshot = takeScreenshot();

        // detect barcode
        string result = GetBarcodeValue(screenshot);

        // If result is detected get information about product
        if (result != null && !result.Equals(lastResult))
        {
            lastResult = result;

            // query json API
            string json = QueryBarcode(result);
            BarcodeAPIResult res_json = ParseJson(json);

            // create informational plane
            pp.placePlane(res_json);
        }        

        Destroy(screenshot);
    }

    /// <summary>
    /// Take screenshot and save as Texture2D
    /// </summary>
    public Texture2D takeScreenshot()
    {
        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        return screenshot;
    }

    /// <summary>
    /// Find EAN-13 Barcode in scene and parse its number
    /// </summary>
    /// <param name="screenshot">Texture2D containing barcode</param>
    /// <returns>Number behind barcode</returns>
    public string GetBarcodeValue(Texture2D screenshot)
    {
        // Create input bitmap
        IBarcodeReader reader = new BarcodeReader();
        var barcodeBitmap = screenshot.GetPixels32();

        // pase result
        var result = reader.Decode(barcodeBitmap, screenshot.width, screenshot.height);

        // return result
        if (result == null) return null;
        return result.ToString();
    }

    /// <summary>
    /// Get API grocery result
    /// </summary>
    /// <param name="barcode">number of barcode</param>
    /// <returns>json of FoodFacts API</returns>
    public string QueryBarcode(string barcode)
    {
        string url = "https://world.openfoodfacts.org/api/v0/product/" + barcode + ".json";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        return jsonResponse;
    }

    /// <summary>
    /// Convert json result to BarcodeAPIResult object
    /// </summary>
    /// <param name="json">json from FoodFacts API</param>
    /// <returns>Object of type BarcodeAPIResult</returns>
    public BarcodeAPIResult ParseJson(string json)
    {
        BarcodeAPIResult myObject = JsonUtility.FromJson<BarcodeAPIResult>(json);
        return myObject;
    }
}
