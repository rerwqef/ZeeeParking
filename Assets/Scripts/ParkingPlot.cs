using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPlot : MonoBehaviour
{
    public float allowedDistance = 0.05f;
    public Material material;
  //  public Transform parkingArea;
 public    PlayerCarController car;
    public CarScriptable carAsset;
    GameManager gm;
    public GameObject winpannel;
    void Start()
    {
        gm=GameManager.Instance;
    //    carAsset=car.Car;
        GameManager.onGameFinished += oNWinPannel;

    }

    // Update is called once per frame
    void Update()
    {
        if (car != null)
        {
            CheckParkingDistance();
        }
      
    }
    private void CheckParkingDistance()
    {
        float distance = Vector3.Distance(car.transform.position, gameObject.transform.position);

        if (distance < allowedDistance)
        {
            if (car.side == drivetype.parking)
            {
              // gm.Activatewinningpannel();
                material.color = Color.red;
                GameManager.onGameFinished?.Invoke();
            }
            else
            {
                material.color = Color.green;
            }
        }
        else
        {
            material.color = Color.yellow;
          
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))

        {
          car= collision.collider.gameObject.GetComponentInParent<PlayerCarController>();
        }
    }
    public void oNWinPannel()
    {
        winpannel.SetActive(true);
    }
}

