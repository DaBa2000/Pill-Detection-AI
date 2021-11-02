using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArrowPlacement : MonoBehaviour
{
    /*
    * AR Scene Management
    */
    // Module to raycast from screen into scene
    private ARRaycastManager rcManager;
    private Vector3 raycastOrigin;

    // Position where red square will be rendered in scene
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    // Red square indicating where final placement will be
    public GameObject placementIndicatorPrefab;
    private GameObject placementIndicator;

    // Red Arrow
    public GameObject arrow;

    // allowing game to run task every x frames
    private int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rcManager = FindObjectOfType<ARRaycastManager>();
        placementIndicator = Instantiate(placementIndicatorPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        raycastOrigin = new Vector3(0.5f * Screen.width, 0.5f * Screen.height, 0);
    }



    void OnApplicationQuit()
    {
        Destroy(placementIndicator);
    }


    // Update is called once per frame
    void Update()
    {
        // Every tenth frame the placement indicator is replaced
        frameCount++;
        if (frameCount % 10 == 0)
        {
            UpdatePlacemetPose();
            UpdatePlacementIndicator();
            frameCount = 0;
        }

    }

    /// <summary>
    /// Check if palcement indicator can be placed, and place it if possible
    /// </summary>
    public void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdatePlacemetPose()
    {
        // Set origin of raycast to position that has been sent from Caregiver View
        raycastOrigin = new Vector3(GameController.marker_x, GameController.marker_y, 0);
        raycastOrigin = Camera.current.ViewportToScreenPoint(raycastOrigin);

        // Send ray into scene and save hits
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        // if hits are detected, the placement indicator can be placed
        if (hits.Count > 0)
        {
            placementPoseIsValid = true;
            placementPose = hits[0].pose;
        }
        else
        {
            placementPoseIsValid = false;
        }
    }

    /// <summary>
    /// Place the AR Arrow at the position that has been sent from the caregiver view
    /// </summary>
    public void setArrow()
    {
        // Set origin of raycast to position that has been sent from Caregiver View
        raycastOrigin = new Vector3(GameController.arrow_x, GameController.arrow_y, 0);
        raycastOrigin = Camera.current.ViewportToScreenPoint(raycastOrigin);

        // Send ray into scene and save hits
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        // if hits are detected, the arrow can be placed
        if (hits.Count > 0)
        {
            Pose p = hits[0].pose;
            arrow.transform.SetPositionAndRotation(p.position, p.rotation);
        }
    }

    /// <summary>
    /// Set arrow material
    /// </summary>
    /// <param name="m">Material arrow should get</param>
    public void setArrowMaterial(Material m)
    {
        arrow.GetComponent<MeshRenderer>().material = m;
    }
}
