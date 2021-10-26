using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.iOS;
using System;

public class ArrowPlacement : MonoBehaviour
{
    private ARSessionOrigin arOrigin;
    private ARRaycastManager rcManager;

    private Pose placementPose;

    private bool placementPoseIsValid = false;

    public GameObject placementIndicatorPrefab;
    private GameObject placementIndicator;

    private Vector3 raycastOrigin;

    public GameObject arrow;

    private int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
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
        frameCount++;

        if (frameCount % 10 == 0)
        {
            UpdatePlacemetPose();
            UpdatePlacementIndicator();
        }

    }

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

    public void UpdatePlacemetPose()
    {
        raycastOrigin = new Vector3(GameController.marker_x, GameController.marker_y, 0);
        raycastOrigin = Camera.current.ViewportToScreenPoint(raycastOrigin);


        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

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

    public void setArrow()
    {
        raycastOrigin = new Vector3(GameController.arrow_x, GameController.arrow_y, 0);
        raycastOrigin = Camera.current.ViewportToScreenPoint(raycastOrigin);


        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            Pose p = hits[0].pose;
            arrow.transform.SetPositionAndRotation(p.position, p.rotation);
        }
    }
}
