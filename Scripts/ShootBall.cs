using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public float maxShootForce = 1000f;
    public float dragDistanceMultiplier = 10.0f; // Adjust this value to control sensitivity
    public int trajectoryPointCount = 30; // Number of points to display in the trajectory
    public float trajectoryPointSpacing = 0.1f; // Spacing between trajectory points

    private Camera arCamera;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isDragging = false;
    private LineRenderer lineRenderer;

    void Start()
    {
        arCamera = Camera.main;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = trajectoryPointCount;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                endTouchPosition = touch.position;
                if (isDragging)
                {
                    VisualizeTrajectory();
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                if (isDragging)
                {
                    Shoot();
                }
                isDragging = false;
                lineRenderer.positionCount = 0; // Clear the trajectory visualization
            }
        }
    }

    private void VisualizeTrajectory()
    {
        Vector2 dragVector = endTouchPosition - startTouchPosition;
        float dragDistance = dragVector.magnitude;
        float shootForce = Mathf.Clamp(dragDistance * dragDistanceMultiplier, 0, maxShootForce);

        Vector3 shootDirection = arCamera.transform.forward;
        Vector3 startPosition = arCamera.transform.position;

        // Simulate the trajectory
        Vector3[] trajectoryPoints = new Vector3[trajectoryPointCount];
        Vector3 currentPosition = startPosition;
        Vector3 currentVelocity = shootDirection * shootForce / ballPrefab.GetComponent<Rigidbody>().mass;

        for (int i = 0; i < trajectoryPointCount; i++)
        {
            trajectoryPoints[i] = currentPosition;
            currentVelocity += Physics.gravity * trajectoryPointSpacing;
            currentPosition += currentVelocity * trajectoryPointSpacing;
        }

        lineRenderer.positionCount = trajectoryPointCount;
        lineRenderer.SetPositions(trajectoryPoints);
    }

    private void Shoot()
    {
        // Calculate drag distance and direction
        Vector2 dragVector = endTouchPosition - startTouchPosition;
        float dragDistance = dragVector.magnitude;

        // Instantiate ball
        GameObject ball = Instantiate(ballPrefab, arCamera.transform.position, arCamera.transform.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Calculate shoot direction and force
        Vector3 shootDirection = arCamera.transform.forward;
        float shootForce = Mathf.Clamp(dragDistance * dragDistanceMultiplier, 0, maxShootForce);

        // Apply force to the ball
        rb.AddForce(shootDirection * shootForce);
    }
}
