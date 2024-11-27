using UnityEngine;

public class RotateLeftAndRight : MonoBehaviour
{
    public float rotationSpeed = 30f; // Rotation speed in degrees per second
    public float rotationAngle = 45f; // Maximum rotation angle

    private float currentAngle = 0f;
    private bool rotatingRight = true;

    void Update()
    {
        float angle = rotationSpeed * Time.deltaTime;

        if (rotatingRight)
        {
            currentAngle += angle;
            if (currentAngle >= rotationAngle)
            {
                currentAngle = rotationAngle;
                rotatingRight = false;
            }
        }
        else
        {
            currentAngle -= angle;
            if (currentAngle <= -rotationAngle)
            {
                currentAngle = -rotationAngle;
                rotatingRight = true;
            }
        }

        transform.rotation = Quaternion.Euler(0, currentAngle, 0);
    }
}
