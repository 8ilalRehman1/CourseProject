using UnityEngine;

public class WheelSpinner : MonoBehaviour
{
    public float turnSpeed = 30f; // Speed for steering
    private bool turningRight = true;

    void Update()
    {
        // Steering logic
        if (turningRight)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime); // Turn right
            if (transform.rotation.eulerAngles.y >= 30f && transform.rotation.eulerAngles.y < 180f)
            {
                turningRight = false; // Switch direction
            }
        }
        else
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime); // Turn left
            if (transform.rotation.eulerAngles.y <= 330f && transform.rotation.eulerAngles.y > 180f)
            {
                turningRight = true; // Switch direction
            }
        }
    }
}
//*https://www.thespruce.com/front-door-colors-4179043*\\