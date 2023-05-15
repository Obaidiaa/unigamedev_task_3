using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public CannonController cannonController;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is began or moved
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                // Calculate the touch position in world coordinates
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                cannonController.RotateCannon(touchPosition);
            }else if (touch.phase == TouchPhase.Ended)
            {
                cannonController.Fire();
            }
        }

        // if (Input.GetMouseButton(0))
        // {
        //     // Rotate the cannon while the mouse button is held
        //     cannonController.RotateCannon(input: Input.GetAxis("Mouse X"));

        // }
        // else if (Input.GetMouseButtonUp(0))
        // {
        //     // Fire the cannon when the mouse button is released
        //     cannonController.Fire();
        // }

        // when move the move down, increase the power of the cannon and reduce it when the mouse move up
        // if (Input.GetAxis("Mouse Y") < 0)
        // {
        //     cannonController.IncreasePower();
        // }
        // else if (Input.GetAxis("Mouse Y") > 0)
        // {
        //     cannonController.DecreasePower();
        // }
    }
}
