using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarController : MonoBehaviour
{
    public GameObject[] bodies;
    private GameManager gm;
    public CAR_Wheelcollider wheelcollider;
    public WheelTransform wheelTransform;
    public string targetTag = "YourTargetTag";
    public drivetype side;

    [Header("Car Engine")]
    public float accilartionForce = 300f;
    public float breackForce = 3000f;
    public float currentBreackForce = 0f;
    public float currentAccelaration = 0f;

    [Header("Car Steering")]
    public float maxsteeiAgangle = 35f;
    public float currentSteeringangle = 0;

    public float allowedDistance = 2f;
    public Material material;
    public Transform parkingArea;

    private Rigidbody rb;
    private Button breack;
    private bool m;
    [SerializeField]
    public  GameObject centerOfMassObject;
    private void Start()
    {
        gm=GameManager.Instance;
        InitializeCar();



    }

   



    private void Update()
    {
        CheckParkingDistance();
       
        Debug.Log("vertical" + Input.GetAxis("Vertical"));
        Debug.Log("horizontal" + Input.GetAxis("Horizontal"));
    }

    private void FixedUpdate()
    {
        MoveCar();
        Applysteering();
       
        updatewheels();
    }

    private void getcar()
    {
        int carIndex = gm.carindex;

        foreach (GameObject body in bodies)
        {
            body.SetActive(false);
        }

        if (carIndex >= 0 && carIndex < bodies.Length)
        {
            bodies[carIndex].SetActive(true);
        }
    }

    private void Applysteering()
    {
        currentSteeringangle = maxsteeiAgangle * SimpleInput.GetAxis("Horizontal");
        wheelcollider.frontleftWheelcollider.steerAngle = currentSteeringangle;
        wheelcollider.frontrightWheelcollider.steerAngle = currentSteeringangle;
    }

    private void MoveCar()
    {
        float verticalInput = SimpleInput.GetAxis("Vertical");

        if (side == drivetype.onlystright && verticalInput > 0)
        {
            
                currentAccelaration = accilartionForce * verticalInput;
            
         
        }
      else   if (side == drivetype.onlyreverce && verticalInput > 0)
        {
            currentAccelaration = -accilartionForce * verticalInput;
        }
    else     if (side == drivetype.parking)
        {
            Applybreak();
        }
  else   if (side == drivetype.Nuttral)
        {
            currentAccelaration = 0f;
        }
     else   if (side == drivetype.alside)
        {
            currentAccelaration = accilartionForce * verticalInput;
        }
        else
        {
            currentAccelaration = 0;
        }

        wheelcollider.backleftWheelcollider.motorTorque = currentAccelaration;
        wheelcollider.backrightWheelcollider.motorTorque = currentAccelaration;
    }

    public void Applybreak()
    {

        StartCoroutine(carBreacks());
     
    }
    IEnumerator carBreacks()
    {
        currentBreackForce = breackForce;
        wheelcollider.frontleftWheelcollider.brakeTorque = currentBreackForce*0.7f;
        wheelcollider.frontrightWheelcollider.brakeTorque = currentBreackForce * 0.7f;
        wheelcollider.backleftWheelcollider.brakeTorque = currentBreackForce * 0.3f;
        wheelcollider.backrightWheelcollider.brakeTorque = currentBreackForce * 0.3f;
        yield return new WaitForSeconds(2);
        currentBreackForce = 0f;
        wheelcollider.frontleftWheelcollider.brakeTorque = currentBreackForce;
        wheelcollider.frontrightWheelcollider.brakeTorque = currentBreackForce;
        wheelcollider.backleftWheelcollider.brakeTorque = currentBreackForce;
        wheelcollider.backrightWheelcollider.brakeTorque = currentBreackForce;

    }
    private void updatewheels()
    {
        updatesinglewheels(wheelcollider.frontleftWheelcollider, wheelTransform.frontleftWheel_tranform);
        updatesinglewheels(wheelcollider.frontrightWheelcollider, wheelTransform.frontrightWheel_tranform);
        updatesinglewheels(wheelcollider.backleftWheelcollider, wheelTransform.backleftWheel_tranform);
        updatesinglewheels(wheelcollider.backrightWheelcollider, wheelTransform.backrightWheel_tranform);
    }

    private void updatesinglewheels(WheelCollider wheelCollider, GameObject wheelTransform)
    {
        if (wheelCollider != null && wheelTransform != null)
        {
            wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
            wheelTransform.transform.rotation = rot;
            wheelTransform.transform.position = pos;
        }
    }

    private void CheckParkingDistance()
    {
        float distance = Vector3.Distance(transform.position, parkingArea.position);

        if (distance < allowedDistance)
        {
            if (side == drivetype.parking)
            {
                gm.Activatewinningpannel();
                material.color = Color.red;
            }
            else
            {
                material.color = Color.green;
            }
        }
        else
        {
            material.color = Color.yellow;
            Debug.Log("Not parked yet");
        }
    }

    public void cartype_changer(int index)
    {
        switch (index)
        {
            case 0:
                side = drivetype.Nuttral;
                break;
            case 1:
                side = drivetype.onlystright;
                break;
            case -1:
                side = drivetype.onlyreverce;
                break;
            case 2:
                side = drivetype.parking;
                break;
            case 4:
                side = drivetype.alside;
                break;
        }
    }


    private void InitializeCar()
    {
        cartype_changer(0);
        getcar();
        rb = GetComponent<Rigidbody>();

        if (centerOfMassObject != null)
        {
            rb.centerOfMass = centerOfMassObject.transform.localPosition;
        }
        else
        {
            // Fallback to hardcoded values if centerOfMassObject is not assigned
            rb.centerOfMass = new Vector3(0f, -0.5f, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
           gm.failedingame();
        }
    }
}

[System.Serializable]
public class CAR_Wheelcollider
{
    public WheelCollider frontleftWheelcollider;
    public WheelCollider frontrightWheelcollider;
    public WheelCollider backleftWheelcollider;
    public WheelCollider backrightWheelcollider;
}

[System.Serializable]
public class WheelTransform
{
    public GameObject frontleftWheel_tranform;
    public GameObject frontrightWheel_tranform;
    public GameObject backleftWheel_tranform;
    public GameObject backrightWheel_tranform;
}

[System.Serializable]
public enum drivetype
{
    alside,
    onlyreverce,
    Nuttral,
    onlystright,
    parking
}