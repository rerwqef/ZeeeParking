using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody target;
    public float maxSpeed = 0.0f; // The maximum speed of the target ** IN KM/H **
    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;
    public float smoothingFactor = 0.1f; // Smoothing factor for the moving average

    [Header("UI")]
    public TextMeshProUGUI speedLabel; // The label that displays the speed;
    public RectTransform arrow; // The arrow in the speedometer

    private float speed = 0.0f;
    private float smoothedSpeed = 0.0f;
    public bool GoodSPeed=false;

    private void Update()
    {
        // 3.6f to convert in kilometers
        // ** The speed must be clamped by the car controller **
        speed = target.velocity.magnitude * 3.6f;

        // Smooth the speed using a moving average
        smoothedSpeed = Mathf.Lerp(smoothedSpeed, speed, smoothingFactor);

        if (speedLabel != null)
            speedLabel.text = ((int)smoothedSpeed) + " km/h";
        if (smoothedSpeed > 3)
        {
            GoodSPeed = true;   
        }

        if (arrow != null)
            arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, smoothedSpeed / maxSpeed));
    }
}
