using UnityEngine;
using Unity.Barracuda;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class ImageDetection : MonoBehaviour
{
    /*
     * Barracuda object detection 
     */

    // YOLOv5 Network ONNX Model
    public NNModel modelAsset;
    // Barracuda Model created from traind YOLO Model
    private Model m_RuntimeModel;
    // Worker that runs inference om the model
    private IWorker m_Worker;

    /*
     * AR detection
     */
    // Arrow indicating detection
    public GameObject arrow;
    // Module to raycast from screen into scene
    private ARRaycastManager rcManager;
    private Vector3 raycastOrigin;

    // Time Measurement
    private float time_sum = 0;
    private int time_index = 0;
    private int runs = 0;
    private float[] times = new float[100];

    // Scene change variables
    bool stopScene;
    string nextScene;


    // Start is called before the first frame update
    void Start()
    {
        stopScene = false;

        // Create Baracuda Model and Worker
        m_RuntimeModel = ModelLoader.Load(modelAsset);
        // ComputePrecompiled is fastest GPU Worker
        m_Worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, m_RuntimeModel);

        // Get Raycastmanager from scene
        rcManager = FindObjectOfType<ARRaycastManager>();

        // start the detection process
        StartCoroutine(detectPill());
    }

    /// <summary>
    /// Whole calssification process for image
    /// </summary>
    /// <param name="image">Image where pills should be detected</param>
    public void ClassifyImage(Texture2D image)
    {
        // Sample image to 320 x 320 version
        int image_size = 320;
        float[] values = sampleImagePixels(image_size, image_size, image);

        // create tensor from image
        var input_tensor = new Tensor(1, image_size, image_size, 3, values);

        // run inference from tensor
        m_Worker.Execute(input_tensor);

        //get ouput tensor
        var output_tensor = m_Worker.PeekOutput("output");

        // Mark pill based on detection
        MarkPill(GameController.GetDetectedPill(), output_tensor, image_size);

        // dispose unnecessary elements
        input_tensor.Dispose();
        output_tensor.Dispose();
        values = null;
    }

    /// <summary>
    /// Runs object detection on phones screenshot
    /// </summary>
    IEnumerator detectPill()
    {
        while(true)
        {
            Texture2D screenshot = takeScreenshot();

            // scene can only be stopped between two detections, therefore it is checked if scene should be stopped in this places
            if (stopScene == false)
            {
                ClassifyImage(screenshot);
            }
            else
            {
                m_Worker.Dispose();
                SceneManager.LoadScene(nextScene);
            }

            // Destroy image for not memory leaks
            Destroy(screenshot);
            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// Takes screenshot of a scnene
    /// </summary>
    /// <returns>taken screenshot</returns>
    public Texture2D takeScreenshot()
    {
        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        return screenshot;
    }

    /// <summary>
    /// Convert image to array for tensor
    /// Rescale image to 320 x 320 and save to array
    /// </summary>
    /// <param name="width">width of rescaled image</param>
    /// <param name="height">height of rescaled image</param>
    /// <param name="image">image</param>
    /// <returns></returns>
    public float[] sampleImagePixels(int width, int height, Texture2D image)
    {
        // array for RGB values (3) from each pixel
        float[] values = new float[width * height * 3];

        for (var y = 0; y < width; y++)
        {
            for (var x = 0; x < height; x++)
            {
                // as model works with images of 3:4 ration images are cot off at bottom and top
                // original image size 2436 x 1125
                // image size in 3:4 ratio: 1500 x 1125
                // 468px cut off top and bottom
                int tx = x * image.width / width;   
                int ty = y * (image.height-936) / height + 468;
                values[(y * height + x) * 3 + 0] = image.GetPixel(tx, ty)[0];
                values[(y * height + x) * 3 + 1] = image.GetPixel(tx, ty)[1];
                values[(y * height + x) * 3 + 2] = image.GetPixel(tx, ty)[2];
            }
        }

        return values;
    }

    /// <summary>
    /// Mark pill based on output tensor
    /// </summary>
    /// <param name="pill">searched pill: 0 -> Aspirin; 1-> Gummibaerchen; 2 -> IbuProfen; 3 -> IbuHexal; 4 -> Sinupret; 5-> Thomapyrin</param>
    /// <param name="output_tensor">output tensor of model</param>
    /// <param name="image_size">images size</param>
    public void MarkPill(int pill, Tensor output_tensor, int image_size)
    {
        // ouput tensor structure:
        // output_tensor[0, a, b, c]
        // a -> index of image in batch
        // b -> index of proposed bounding boxes
        // c -> information about bounding box
        //        0 -> bounding box confidence
        //     1, 2 -> x and y coordinate of bounding box center
        //     3, 4 -> width and height of bounding box
        //   5 - 11 -> singe class confidences for pills

        // Find boundig box with highest confidene of being searched pill among all bounding boxes with confidence larger 0.7
        float max_pill_value = 0;
        int max_pill_index = -1;

        for (int i = 0; i < 6300; i++)
        {
            if (output_tensor[0, 0, 5 + pill, i] > max_pill_value && output_tensor[0, 0, 4, i] > 0.7)
            {
                max_pill_value = output_tensor[0, 0, 5 + pill, i];
                max_pill_index = i;
            }
        }

        // find bounding box with highest confidence score among all bounding boxes with IOU > 0.5 to original bounding box
        float max_bb_value = 0;
        int max_bb_index = -1;

        if (max_pill_index != -1)
        {
            for (int i = 0; i < 6300; i++)
            {
                // calculate IOU
                float xIntersect = output_tensor[0, 0, 2, i]/2.0f + output_tensor[0, 0, 2, max_pill_index]/2.0f - Math.Abs(output_tensor[0, 0, 0, i] - output_tensor[0, 0, 0, max_pill_index]);
                float yIntersect = output_tensor[0, 0, 3, i] / 2.0f + output_tensor[0, 0, 3, max_pill_index] / 2.0f - Math.Abs(output_tensor[0, 0, 1, i] - output_tensor[0, 0, 1, max_pill_index]);

                float intersection = xIntersect * yIntersect;
                float union = output_tensor[0, 0, 2, i] * output_tensor[0, 0, 3, i] + output_tensor[0, 0, 2, max_pill_index] * output_tensor[0, 0, 3, max_pill_index] - intersection;
                float IOU = intersection / union;

                // Check if IOU is > 0.5 and if confidence is higher than currently highest confidence
                if (output_tensor[0, 0, 4, i] > max_bb_value && IOU > 0.5)
                {
                    max_bb_value = output_tensor[0, 0, 4, i];
                    max_bb_index = i;
                }
            }
        }

        // Draw bounding box / place arrow
        if (max_pill_value > 0.5 && max_bb_index != -1)
        {
            float x = output_tensor[0, 0, 0, max_bb_index] / (float) image_size;
            float y = output_tensor[0, 0, 1, max_bb_index] / (float) image_size;

            // send raycast from detected bounding box center into scene
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastOrigin = new Vector3(x, (y * 0.6158f) + 0.192f, 0);
            raycastOrigin = Camera.main.ViewportToScreenPoint(raycastOrigin);
            rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            // place arrow on pill
            if (hits.Count > 0)
            {
                Pose placementPose = hits[0].pose;
                arrow.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
            }
        }

        output_tensor.Dispose();
    }

    /// <summary>
    /// quit scene in between detections
    /// </summary>
    /// <param name="nextScene">next scene that should be opened</param>
    public void quitScene(string nextScene)
    {
        stopScene = true;
        this.nextScene = nextScene;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////// Time Management /////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Measure time necessary for detections
    /// </summary>
    /// <param name="image">image on which pills should be detected</param>
    public void MeasureDetectionStats(Texture2D image)
    {
        // Sample image to 320 x 320 version
        int image_size = 320;
        var values = sampleImagePixels(image_size, image_size, image);

        // create tensor from image
        var input_tensor = new Tensor(1, image_size, image_size, 3, values);

        // set starting time
        float time = Time.realtimeSinceStartup;

        // run inference from tensor
        m_Worker.Execute(input_tensor);

        // calculate time delta
        float time_delta = Time.realtimeSinceStartup - time;
        time_index++;

        // if enough detections have been made, calculate statistics
        if (time_index >= times.Length)
        {
            CalcStats(times);
        }
        // else save mesasured time
        else
        {
            times[time_index] = time_delta;
        }

        // get ouput tensor
        var output_tensor = m_Worker.PeekOutput("output");

        // dispose unnecessary elements
        input_tensor.Dispose();
        output_tensor.Dispose();
        UnityEngine.Object.Destroy(image);
    }

    /// <summary>
    /// Calculate interesting stats on detection
    /// </summary>
    /// <param name="values">detection durations</param>
    public void CalcStats(float[] values)
    {
        float sum_values = 0;
        float minValue = float.MaxValue;
        float maxValue = float.MinValue;

        float sumDeviation = 0;

        for (int i = 0; i < values.Length; i++)
        {
            sum_values += values[i];

            // determine min and max duration
            if (values[i] < minValue && values[i] > 0.2) minValue = values[i];
            if (values[i] > maxValue && i > 3) maxValue = values[i];
        }

        // calculate mean duration
        float mean = sum_values / (float)values.Length;

        for (int i = 0; i < values.Length; i++)
        {
            sumDeviation += (values[i] - mean) * (values[i] - mean);
        }

        Debug.Log("--------------------------------------------------------");
        Debug.Log("--------------------------------------------------------");
        Debug.Log("Average Time: " + mean);
        Debug.Log("--------------------------------------------------------");
        Debug.Log("Min: " + minValue + " - Max: " + maxValue);
        Debug.Log("--------------------------------------------------------");
        Debug.Log("Variance: " + Mathf.Sqrt((sumDeviation) / values.Length) + " Std. deviation: " + (sumDeviation) / values.Length);
        Debug.Log("--------------------------------------------------------");
        Debug.Log("--------------------------------------------------------");
    }
}