using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    public float speed = -1f; // Adjust this value to control the cloud's movement speed.
    public float leftBoundary = 10f; // The leftmost boundary where the cloud should respawn.
    public float rightBoundary = -10f; // The rightmost boundary where the cloud should respawn.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move the cloud to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //if the cloud is past the left boundary, move it to the right boundary
        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector2(rightBoundary, transform.position.y);
        }


    }
}
