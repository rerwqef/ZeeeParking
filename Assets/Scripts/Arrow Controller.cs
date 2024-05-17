using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform parkingSpot; // Set this in the inspector
    public float rotationSpeed = 5f;
    public Transform car;
    void Update()
    {
        transform.position = car.position+new Vector3(0,1,0);
        if (parkingSpot != null)
        {
            // Get the direction to the parking spot
            Vector3 directionToSpot = parkingSpot.position - transform.position;

            // Calculate the rotation towards the parking spot
            Quaternion targetRotation = Quaternion.LookRotation(directionToSpot);

            // Smoothly rotate the arrow towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}