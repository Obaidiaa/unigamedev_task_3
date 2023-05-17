using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 300f;
    public float firingForce = 500f;
    public GameObject ballPrefab;

    public int trajectoryPointCount = 30;
    public float trajectoryPointSpacing = 0.3f;
    public float trajectorySimulationTime = 2f;

    public GameObject canonExit;
    private bool isFiring = false;
    private float rotationInput = 0f;



    public GameObject canon;
    private LineRenderer trajectoryRenderer;

    void Start()
    {
        trajectoryRenderer = GetComponent<LineRenderer>();
        //width of the line renderer
        trajectoryRenderer.startWidth = 0.1f;
        trajectoryRenderer.endWidth = 0.1f;
        //set the number of points to draw
        trajectoryRenderer.positionCount = trajectoryPointCount;



    }


    void Update()
    {
        if (isFiring)
            return;

        // Rotate the cannon based on player input
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        canon.transform.Rotate(Vector3.forward, rotation);

        // Clamp the rotation to prevent the cannon from rotating too far
        float zRotation = transform.eulerAngles.z;
        if (zRotation > 90 && zRotation < 180)
        {
            zRotation = 90;
        }
        else if (zRotation < 270 && zRotation > 180)
        {
            zRotation = 270;
        }
        transform.eulerAngles = new Vector3(0, 0, zRotation);


        // limit the power of the cannon
        if (firingForce > 800f)
        {
            firingForce = 800f;
        }
        else if (firingForce < 100f)
        {
            firingForce = 100f;
        }


        // Draw the trajectory arc
        DrawTrajectory();


    }

    public void Fire()
    {
        if (isFiring)
            return;


        // Instantiate the ball prefab
        GameObject ball = Instantiate(ballPrefab, canonExit.transform.position, Quaternion.identity);

        // Calculate the direction based on the cannon's rotation
        Vector3 direction = transform.up;

        // Apply a force to the ball in the calculated direction
        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballRigidbody.AddForce(canonExit.transform.right * firingForce);

        isFiring = false;
    }


    // Draw trajectory 2d arc using the LineRenderer component and the trajectoryPointCount and trajectoryPointSpacing variables to determine the number of points to draw and the spacing between them respectively and gravity and drag.  
    void DrawTrajectory()
    {
        Vector3[] points = new Vector3[trajectoryPointCount];

        // Calculate the velocity using the initial angle and velocity magnitude 
        Vector2 velocity = canonExit.transform.right * firingForce * 0.02f;

        // Calculate the initial position
        Vector2 position = canonExit.transform.position;

        // Simulate the trajectory
        for (int i = 0; i < trajectoryPointCount; i++)
        {
            float time = i * Time.fixedDeltaTime * trajectorySimulationTime;

            // Calculate the trajectory point using the kinematic equations for projectile motion 
            points[i] = position + velocity * time + 0.5f * Physics2D.gravity * time * time;

            // Check if the point has collided with something
            if (Physics2D.OverlapCircle(points[i], 0.01f))
            {
                trajectoryPointCount = i;
                break;
            }
        }

        // Update the line renderer with the calculated points
        trajectoryRenderer.positionCount = trajectoryPointCount;
        trajectoryRenderer.SetPositions(points);
    }

    





    public void RotateCannon(Vector3 touchPosition)
    {
        // Calculate the direction from the cannon to the touch position
        Vector3 direction = touchPosition - transform.position;
        direction.z = 0f;

        // Calculate the rotation angle based on the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the cannon to face the touch
        canon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    public void IncreasePower()
    {
        firingForce += 100f;
    }

    public void DecreasePower()
    {
        firingForce -= 100f;
    }
}
