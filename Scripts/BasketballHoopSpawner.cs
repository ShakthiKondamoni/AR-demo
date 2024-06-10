using UnityEngine;

public class BasketballHoopSpawner : MonoBehaviour
{
    // Reference to the basketball hoop prefab
    public GameObject basketballHoopPrefab;
    
    // Flag to check if the hoop has been instantiated
    private bool hoopInstantiated = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the screen is touched or mouse is clicked and the hoop has not been instantiated yet
        if (Input.GetMouseButtonDown(0) && !hoopInstantiated)
        {
            // Get the touch or click position
            Vector3 touchPosition = Input.mousePosition;
            touchPosition.z = 10f; // Set the distance from the camera

            // Convert the touch position to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // Instantiate the basketball hoop at the world position
            Instantiate(basketballHoopPrefab, worldPosition, Quaternion.identity);

            // Set the flag to true to prevent further instantiation
            hoopInstantiated = true;
        }
    }
}
