using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcars : MonoBehaviour
{
    public Transform path;
    public float maxSteeringAngle = 130f;
    public float steeringCorrectionFactor = 0.5f; // Adjust this value for smoother steering
    public float maxmotorTorque = 80f;
    public float currentSpeed;
    public float maxSpeed=100;
    public float maxBreacktorque=150;
  public WheelCollider wheelfl;
    public WheelCollider wheelfr;
    public WheelCollider wheelrl;
    public WheelCollider wheelrr;
    public Vector3 centerofMass;
  //  public GameObject sesor_obj;
    public bool isbreacking=false;

    [Header("sensors")]
    public float sensorsLength = 5f;
    public Vector3 frontsensorpos= new Vector3 (0,0.2f,0.5f);
    public float sidesensorposition=0.2f;
    public float frontsidstsencerangle = 30;
    private List<Transform> nodes;
    private int currentNode=0;
    public  bool avoiding = false;
    bool onGmaefished;
   // public bool m;
    void Start()
    {
      
        GetComponent<Rigidbody>().centerOfMass = centerofMass;
        Transform[] PathTransforms = path.GetComponentsInChildren<Transform>();
        
        nodes = new List<Transform>();
       
        
            for (int i = 0; i < PathTransforms.Length; i++)
            {
                if (PathTransforms[i] != path.transform)
                {
                    nodes.Add(PathTransforms[i]);
                }
            }
        
        
        
    }
    public void ongamefished()
    {
        onGmaefished = true;
    }
    void FixedUpdate()
    {
        if (!onGmaefished)
        {
            sensors();
            ApplySteering();
            Drive();
            CheckWaypointDistance();
            Braking();
        }
    }

    void ApplySteering()
    {
        if (avoiding) return;
        
            Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);

            // Calculate the new steering angle
            float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteeringAngle * steeringCorrectionFactor;

            wheelfl.steerAngle = newSteer;
            wheelfr.steerAngle = newSteer;
        
      
    }

    void Drive()
    {
        currentSpeed=2*Mathf.PI*wheelfl.radius*wheelfl.rpm*60/1000;
        if (currentSpeed < maxSpeed && !isbreacking)
        {
            wheelfl.motorTorque = maxmotorTorque;
            wheelfr.motorTorque = maxmotorTorque;
        }
        else
        {
            wheelfl.motorTorque = 0;
            wheelfr.motorTorque = 0;
        }
      
    }

    void CheckWaypointDistance()
    {

        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 5f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }
    private void Braking()
    {
        if(isbreacking)
        {
            wheelfl.brakeTorque = maxBreacktorque;
            wheelfr.brakeTorque = maxBreacktorque;
            wheelrl.brakeTorque= maxBreacktorque;
            wheelrr.brakeTorque=maxBreacktorque;
        }
        else
        {
            wheelfl.brakeTorque = 0;
            wheelfr.brakeTorque = 0;
            wheelrl.brakeTorque = 0;
            wheelrr.brakeTorque = 0;

        }
    }
    public void sensors()
    {
        RaycastHit hit;
        Vector3 sensorstsrtpos = transform.position;
        sensorstsrtpos += transform.forward * frontsensorpos.z;
        sensorstsrtpos += transform.up * frontsensorpos.y;
        float avoidMultipler = 0;
      
        //front
        if(Physics.Raycast(sensorstsrtpos,transform.forward,out hit,sensorsLength))
        {
            if (!hit.collider.CompareTag("terrain")){
                Debug.DrawLine(sensorstsrtpos, hit.point);
                avoiding=true;
            }
            else
            {
                avoiding = false;
            }
        }
       
        //rightside
        sensorstsrtpos +=transform.right* sidesensorposition;

        if (Physics.Raycast(sensorstsrtpos, transform.forward, out hit, sensorsLength))
        {

            if (!hit.collider.CompareTag("terrain"))
            {
                Debug.DrawLine(sensorstsrtpos, hit.point);
                avoiding = true;
                avoidMultipler +=1;
            }
            else
            {
                avoiding = false;
            }
        }
     



    else if (Physics.Raycast(sensorstsrtpos,Quaternion.AngleAxis(-frontsidstsencerangle,transform.up)*transform.forward, out hit, sensorsLength))
        {

            if (!hit.collider.CompareTag("terrain"))
            {
                Debug.DrawLine(sensorstsrtpos, hit.point);
                avoiding = true;
                avoidMultipler += 0.5f;
            }
            else
            {
                avoiding = false;
            }
        }
      


        //leftside
        sensorstsrtpos -= transform.right * sidesensorposition*2;

        if (Physics.Raycast(sensorstsrtpos, transform.forward, out hit, sensorsLength))
        {

            if (!hit.collider.CompareTag("terrain"))
            {
                Debug.DrawLine(sensorstsrtpos, hit.point);
                avoiding = true;
                avoidMultipler -= 1f;
            }
            else
            {
                avoiding = false;
            }
        }
     

     else  if (Physics.Raycast(sensorstsrtpos, Quaternion.AngleAxis(frontsidstsencerangle, transform.up) * transform.forward, out hit, sensorsLength))
        {

            if (!hit.collider.CompareTag("terrain"))
            {
                Debug.DrawLine(sensorstsrtpos, hit.point);
                avoiding = true;
                avoidMultipler -= 0.5f;
            }
            else
            {
                avoiding = false;
            }
        }

        if (avoiding)
        {

            isbreacking = true;
        }
        else
        {
            isbreacking = false;
        }        
    }
}
