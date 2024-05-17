using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarController : MonoBehaviour
{
 //   public GameObject[] bodies;
    private GameManager gm;
    public CAR_Wheelcollider wheelcollider;
    public CarScriptable Car;
    public WheelTransform wheelTransform;
    public string targetTag;
    public drivetype side;

    public CinemachineVirtualCamera virtualCamera;
    public float currentBreackForce = 0f;
    public float currentAccelaration = 0f;
    public float currentSteeringangle = 0;
    [Header("Car Steering")]

   float dragCoefficient = 0.3f;


    bool GameFinshed=false;

    private Rigidbody rb;
    private Button breack;
    private bool m;
    [SerializeField]
    public Transform centerOfMassObject;
 public    bool breackking = true;


    [Header("audio")]
    public AudioSource audioSource;
    public AudioClip accelarationSound;
    public AudioClip slowAcclarationSound;
    public AudioClip brakeSound;

    public Cinemachine3rdPersonAim camm;
    private void Start()
    {
        gm = GameManager.Instance;
        GameManager.onGameStarted += InitializeCar;
        GameManager.onGameStarted?.Invoke();
        GameManager.onGameFinished += ONGmeFishedInput;
        GameManager.onGameFinished += carBreacks;
      
    }
    public void ONGmeFishedInput()
    {
        GameFinshed = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            breackking = true;
        }
        else
        {

            breackking = false;
        }
        applybreack();
    }
    private void FixedUpdate()
    {
        if (!GameFinshed)
        {
           
            MoveCar();
            Applysteering();
          updatewheels();
            //   carBreacks();
        }
        else
        {
            breackking = true;
        }
       
    }
  /*  private void getcar()
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
    }*/
    private void Applysteering()
    {
        currentSteeringangle = Car.maxsteeiAgangle * SimpleInput.GetAxis("Horizontal");
        wheelcollider.frontleftWheelcollider.steerAngle = currentSteeringangle;
        wheelcollider.frontrightWheelcollider.steerAngle = currentSteeringangle;
    }
    private void MoveCar()
    {
        float verticalInput = SimpleInput.GetAxis("Vertical");
      float currentSpeed = wheelcollider.backleftWheelcollider.rpm * (2 * Mathf.PI * wheelcollider.backleftWheelcollider.radius) / 60; // Calculate current speed in meters per second

        currentAccelaration = 0;
        if (side == drivetype.onlystright && verticalInput > 0)
        {
            currentAccelaration = Car.accilartionForce * verticalInput;
        }
        else if (side == drivetype.onlyreverce && verticalInput > 0)
        {
            currentAccelaration = -Car.accilartionForce * verticalInput;
        }
        else if (side == drivetype.parking)
        {
            currentAccelaration = 0;
            breackking = true;
      //      GameManager.onGameFinished?.Invoke();
        }
        else if (side == drivetype.Nuttral)
        {
            currentAccelaration = 0f;
        }
        else if (side == drivetype.alside)
        {
            currentAccelaration = Car.accilartionForce * verticalInput;
        }
     
         
        

        // Apply drag force to reduce speed at high velocities
     
        
            float dragForce = -dragCoefficient * currentSpeed; // Drag force equation (F = -bv)
            currentAccelaration += dragForce;

            wheelcollider.backleftWheelcollider.motorTorque = currentAccelaration;
            wheelcollider.backrightWheelcollider.motorTorque = currentAccelaration;

        
     
/*
        if (currentAccelaration > 0)
        {
            audioSource.PlayOneShot(accelarationSound, 0.2f);
        }else if(currentAccelaration < 0)
        {
            audioSource.PlayOneShot(accelarationSound, 0.2f);
        }*/
    }
    public void carBreacks()
    {
        currentBreackForce = Car.breackForce;
        wheelcollider.frontleftWheelcollider.brakeTorque = currentBreackForce * 0.7f;
        wheelcollider.frontrightWheelcollider.brakeTorque = currentBreackForce * 0.7f;
        wheelcollider.backleftWheelcollider.brakeTorque = currentBreackForce * 0.3f;
        wheelcollider.backrightWheelcollider.brakeTorque = currentBreackForce * 0.3f;
    }
    void applybreack()
    {
        if (breackking) currentBreackForce = Car.breackForce;
        else currentBreackForce = 0;
      //  audioSource.PlayOneShot(brakeSound, 0.1f);
        wheelcollider.frontleftWheelcollider.brakeTorque = currentBreackForce * 0.7f;
        wheelcollider.frontrightWheelcollider.brakeTorque = currentBreackForce * 0.7f;
        wheelcollider.backleftWheelcollider.brakeTorque = currentBreackForce * 0.3f;
        wheelcollider.backrightWheelcollider.brakeTorque = currentBreackForce * 0.3f;
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
        // getcar();

        if (rb != null)
        {
            rb = GetComponent<Rigidbody>();
        }
     
  //  rb.centerOfMass = centerOfMassObject.position;
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