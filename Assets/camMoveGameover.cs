using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoveGameover : MonoBehaviour
{
    public Transform centerPoint;   // The center point of the half-circle
    public float radius = 5f;       // The radius of the half-circle path
    public float duration = 5f;     // The duration of the movement in seconds

    private float startAngle =0f;  // The starting angle of the camera movement
    private float stopAngle = 180f; // The stopping angle of the camera movement
    private float elapsedTime = 0f; // The elapsed time since the movement started
    bool Gameover=false;
    public void setparent()
    {
    //    transform.SetParent(transform);
    }
    private void Start()
    {

        GameManager.onGaMeOver += GAMEOverCamMove;       
    }
    void Update()
    {
    /*    if (!Gameover) return; 
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;
       
        // Calculate the interpolation value (t) between 0 and 1 based on the elapsed time
        float t = Mathf.Clamp01(elapsedTime / duration);

        // Interpolate between the start and stop angles using Lerp
        float currentAngle = Mathf.Lerp(startAngle, stopAngle, t);

        // Convert the angle to radians
        float angleInRadians = currentAngle * Mathf.Deg2Rad;

        // Calculate the camera position along the half-circle path
        Vector3 newPosition = new Vector3(centerPoint.position.x + Mathf.Cos(angleInRadians) * radius,
                                          centerPoint.position.y,
                                          centerPoint.position.z + Mathf.Sin(angleInRadians) * radius);

        // Set the camera position
        transform.position = newPosition;

        // Look at the center point while moving
        transform.LookAt(centerPoint.position);

        // Check if the movement has reached its end
        if (t >= 1f)
        {
            // Movement has completed, reset the elapsed time
            elapsedTime = 0f;

            // Swap start and stop angles to allow continuous movement in both directions
            float temp = startAngle;
            startAngle = stopAngle;
            stopAngle = temp + 180f; // Move to the next half-circle path
        }*/
    }
    public void  GAMEOverCamMove()
    {
       Gameover = true;
    }
}
