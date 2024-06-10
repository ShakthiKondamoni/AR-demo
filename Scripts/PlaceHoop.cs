using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlaceHoop : MonoBehaviour
{
    public GameObject hoopPrefab; // The prefab for the basketball hoop to be placed.
    public GameObject placementIndicator; // The visual indicator for where the hoop will be placed.

    private ARRaycastManager arRaycastManager; // Manages raycasting for AR.
    private Pose placementPose; // The position and rotation of the placement indicator.
    private bool placementPoseIsValid = false; // Whether a valid placement pose has been found.
    private GameObject spawnedHoop; // A reference to the spawned hoop.

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>(); // Initialize the ARRaycastManager.
    }

    void Update()
    {
        UpdatePlacementPose(); // Update the placement pose based on detected planes.
        UpdatePlacementIndicator(); // Update the visual indicator's position and visibility.

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceHoopObject(); // Place the hoop when a valid placement pose is found and the screen is tapped.
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f)); // Get the center of the screen.
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes); // Perform a raycast from the center of the screen to detect planes.

        placementPoseIsValid = hits.Count > 0; // Check if any planes were hit.
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose; // Set the placement pose to the first hit pose.
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true); // Show the placement indicator.
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation); // Move the placement indicator to the valid pose.
        }
        else
        {
            placementIndicator.SetActive(false); // Hide the placement indicator if no valid pose is found.
        }
    }

    private void PlaceHoopObject()
    {
        if (spawnedHoop == null)
        {
            spawnedHoop = Instantiate(hoopPrefab, placementPose.position, placementPose.rotation); // Instantiate the hoop at the placement pose.
        }
    }
}
