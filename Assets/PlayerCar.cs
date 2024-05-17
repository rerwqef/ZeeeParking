using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerCar : MonoBehaviour
{

    public GameObject[] cars;
    public CinemachineFreeLook cam;
   
    GameManager gm;

    public Speedometer sp;
    PlayerCarController ScComponent;
    public ParkingPlot Plot;
    public ArrowController arrow;
    public void Start()
    {
        gm=GameManager.Instance;
      
        SelectCar();
      
    }
   public void SelectCar()
    {
        for(int i=0;i<cars.Length; i++)
        {
            if (i==gm.carindex)
            {
                cars[i].SetActive(true);
                if (sp.target == null)
                {
                    sp.target = cars[i].GetComponent<Rigidbody>();
                }
         ScComponent= cars[i].GetComponentInParent<PlayerCarController>();
                Transform c = ScComponent.GetComponent<Transform>();
                c = arrow.car;
               
                Plot.car=ScComponent;
                if (cam != null)
                {
                    // Ensure the Cinemachine camera follows and looks at the selected car
                    Transform carTransform = cars[i].transform;

                    cam.LookAt = carTransform;
                    cam.Follow = carTransform;
                    
                }
            }
            else
            {
                cars[i].SetActive(false);
            }
        }
       
    }
    public void gearButtonsetter(int value)
    {
        ScComponent.cartype_changer(value);
    }
    public void camFaing()
    {

    }
}
