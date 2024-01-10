using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carwheels : MonoBehaviour
{
    public WheelCollider targetWheel;
    private Vector3 wheelposition = new Vector3();
    private Quaternion WheelRotation =  new Quaternion();




    // Update is called once per frame
    void Update()
    {
        targetWheel.GetWorldPose(out wheelposition, out WheelRotation);
        transform.position = wheelposition;
        transform.rotation = WheelRotation;
    }
}
