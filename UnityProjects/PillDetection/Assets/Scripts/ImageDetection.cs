using UnityEngine;
using UnityEditor;
using Unity.Barracuda;

using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using System;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;

public class ImageDetection : MonoBehaviour
{
    // Barracuda Model
    public NNModel modelAsset;
    private Model m_RuntimeModel;
    private IWorker m_Worker;

    // Bounding Box drawing
    public MeshGenerator meshGen;
    public GameObject text;

    public GameObject arrow;

    private ARSessionOrigin arOrigin;
    private ARRaycastManager rcManager;
    private Vector3 raycastOrigin;

    // Time Measurement
    private float time_sum = 0;
    private int time_index = 0;
    private int runs = 0;

    private float[] times = new float[100];

    bool stopScene;
    string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        stopScene = false;

        // Create Baracuda Worker
        m_RuntimeModel = ModelLoader.Load(modelAsset);
        m_Worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, m_RuntimeModel);

        arOrigin = FindObjectOfType<ARSessionOrigin>();
        rcManager = FindObjectOfType<ARRaycastManager>();

        StartCoroutine(detectPill());
    }

    void Update()
    {
        
    }

    IEnumerator detectPill()
    {
        while(true)
        {
            Texture2D screenshot = takeScreenshot();
            if (stopScene == false)
            {
                ClassifyImage(screenshot);
            }
            else
            {
                m_Worker.Dispose();
                SceneManager.LoadScene(nextScene);
            }
            Destroy(screenshot);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public Texture2D takeScreenshot()
    {
        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        return screenshot;
    }

    public float[] sampleImagePixels(int width, int height, Texture2D image)
    {
        // Image Size 2436 1125 -> 1500 = - 468 everywhere
        float[] values = new float[width * height * 3];

        for (var y = 0; y < width; y++)
        {
            for (var x = 0; x < height; x++)
            {
                int tx = x * image.width / width;   
                int ty = y * (image.height-936) / height + 468;
                values[(y * height + x) * 3 + 0] = image.GetPixel(tx, ty)[0];
                values[(y * height + x) * 3 + 1] = image.GetPixel(tx, ty)[1];
                values[(y * height + x) * 3 + 2] = image.GetPixel(tx, ty)[2];
            }
        }

        return values;
    }

    public void MarkPill(int pill, Tensor output_tensor, int image_size)
    {
        // Find boundinb box with highest confidene of searched pill among all bounding boxes with confidence larger 0.7
        // pill: 0 -> Aspirin; 1-> Gummibaerchen; 2 -> IbuProfen; 3 -> IbuHexal; 4 -> Sinupret; 5-> Thomapyrin
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

        float max_bb_value = 0;
        int max_bb_index = -1;

        if (max_pill_index != -1)
        {
            for (int i = 0; i < 6300; i++)
            {
                float xIntersect = output_tensor[0, 0, 2, i]/2.0f + output_tensor[0, 0, 2, max_pill_index]/2.0f - Math.Abs(output_tensor[0, 0, 0, i] - output_tensor[0, 0, 0, max_pill_index]);
                float yIntersect = output_tensor[0, 0, 3, i] / 2.0f + output_tensor[0, 0, 3, max_pill_index] / 2.0f - Math.Abs(output_tensor[0, 0, 1, i] - output_tensor[0, 0, 1, max_pill_index]);

                float intersection = xIntersect * yIntersect;
                float union = output_tensor[0, 0, 2, i] * output_tensor[0, 0, 3, i] + output_tensor[0, 0, 2, max_pill_index] * output_tensor[0, 0, 3, max_pill_index] - intersection;
                float IOU = intersection / union;

                if (output_tensor[0, 0, 4, i] > max_bb_value && IOU > 0.5)
                {
                    max_bb_value = output_tensor[0, 0, 4, i];
                    max_bb_index = i;
                }
            }
        }

        if (max_pill_value > 0.5 && max_bb_index != -1)
        {
            float x = output_tensor[0, 0, 0, max_bb_index] / (float) image_size;
            float y = output_tensor[0, 0, 1, max_bb_index] / (float) image_size;
            float dx = output_tensor[0, 0, 2, max_bb_index] / (float) image_size;
            float dy = output_tensor[0, 0, 3, max_bb_index] / (float) image_size;

            float x1 = ((x - (dx / 2.0f)) * 5.6f) - 2.8f;
            float y1 = ((y - (dy / 2.0f)) * 7.46f) - 2.73f;
            float x2 = ((x + (dx / 2.0f)) * 5.6f) - 2.8f;
            float y2 = ((y + (dy / 2.0f)) * 7.46f) - 2.73f;

            //meshGen.GenerateMesh(x1, y1, x2, y2);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            raycastOrigin = new Vector3(x, (y * 0.6158f) + 0.192f, 0);
            raycastOrigin = Camera.main.ViewportToScreenPoint(raycastOrigin);

            rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (hits.Count > 0)
            {
                Pose placementPose = hits[0].pose;
                arrow.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
            }
        }

        output_tensor.Dispose();
    }

    public void ClassifyImage(Texture2D image)
    {
        int image_size = 320;
        float[] values = sampleImagePixels(image_size, image_size, image);

        var input_tensor = new Tensor(1, image_size, image_size, 3, values);

        m_Worker.Execute(input_tensor);

        var output_tensor = m_Worker.PeekOutput("output");

        MarkPill(GameController.GetDetectedPill(), output_tensor, image_size);

        input_tensor.Dispose();
        output_tensor.Dispose();
        values = null;
    }

    public void quitScene(string nextScene)
    {
        stopScene = true;
        this.nextScene = nextScene;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////// Time Management /////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void MeasureDetectionStats(Texture2D image)
    {
        int image_size = 320;
        var values = sampleImagePixels(image_size, image_size, image);
        var input_tensor = new Tensor(1, image_size, image_size, 3, values);

        float time = Time.realtimeSinceStartup;

        m_Worker.Execute(input_tensor);

        float time_delta = Time.realtimeSinceStartup - time;
        time_index++;

        if (time_index >= times.Length)
        {
            CalcStats(times);
        }
        else
        {
            times[time_index] = time_delta;
        }

        var output_tensor = m_Worker.PeekOutput("output");

        input_tensor.Dispose();
        output_tensor.Dispose();
        UnityEngine.Object.Destroy(image);
    }

    public void CalcStats(float[] values)
    {
        float sum_values = 0;
        float minValue = float.MaxValue;
        float maxValue = float.MinValue;

        float sumDeviation = 0;

        for (int i = 0; i < values.Length; i++)
        {
            sum_values += values[i];

            if (values[i] < minValue && values[i] > 0.2) minValue = values[i];
            if (values[i] > maxValue && i > 3) maxValue = values[i];
        }


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


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////// Other Algorithms ///////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////// SoftMax /////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/*
var validBBList = new List<int>();
var detections = new List<int>();

while (validBBList.Count != 0)
{
    float max_objectiveness_score = 0;
    int max_score_index = -1;
    int max_pill_score = 0;

    foreach (int i in validBBList)
    {
        float max_class_score = 0;
        int max_class_index = -1;

        for (int j = 0; j < 6; j++)
        {
            if (output_tensor[0, 0, 5 + j, i] > max_class_score)
            { // x1 y1 x2 y2 conf cls
                max_class_score = output_tensor[0, 0, 5 + j, i];
                max_class_index = j;
            }
        }

        max_pill_score = max_class_index;

        if (output_tensor[0, 0, 5 + max_class_index, i] > max_objectiveness_score)
        {
            max_objectiveness_score = output_tensor[0, 0, 5 + max_class_index, i];
            max_score_index = i;
        }
    }

    float x_v = output_tensor[0, 0, 0, max_score_index];
    float y_v = output_tensor[0, 0, 1, max_score_index];
    float width_v = output_tensor[0, 0, 2, max_score_index];
    float height_v = output_tensor[0, 0, 3, max_score_index];

    foreach (int i in validBBList)
    {
        if (i == max_score_index)
        {
            break;
        }

        float x_c = output_tensor[0, 0, 0, max_score_index];
        float y_c = output_tensor[0, 0, 1, max_score_index];
        float width_c = output_tensor[0, 0, 2, max_score_index];
        float height_c = output_tensor[0, 0, 3, max_score_index];

        float overlap = Math.Abs(x_v - x_c) * Math.Abs(y_v - y_c);
        float intersection = width_v * height_v + width_c * height_c - overlap;

        if (overlap / intersection > 0.5)
        {
            validBBList.Remove(i);
        }
    }

    detections.Add(max_score_index);
    validBBList.Remove(max_score_index);
    Debug.Log(validBBList.Count);
}

float x = output_tensor[0, 0, 0, detections[0]] / (float)image_size;
float y = output_tensor[0, 0, 1, detections[0]] / (float)image_size;
float dx = output_tensor[0, 0, 2, detections[0]] / (float)image_size;
float dy = output_tensor[0, 0, 3, detections[0]] / (float)image_size;

float x1 = ((x - (dx / 2.0f)) * 5.6f) - 2.8f;
float y1 = ((y - (dy / 2.0f)) * 7.46f) - 2.73f;
float x2 = ((x + (dx / 2.0f)) * 5.6f) - 2.8f;
float y2 = ((y + (dy / 2.0f)) * 7.46f) - 2.73f;


meshGen.GenerateMesh(x1, y1, x2, y2);
*/