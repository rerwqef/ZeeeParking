using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Menumanger : MonoBehaviour
{
    public List<GameObject> cars;

    private GameManager gameManager;

    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public CinemachineVirtualCamera cam3;
    public CinemachineVirtualCamera cam4;

    public void Start()
    {
        gameManager=GameManager.Instance;
        cam1.Priority = 19;
        cam2.Priority = 9;
        cam3.Priority = 9;
        cam4.Priority = 9;
    }


    public void swichcar_increment()
    {
    }
    public void swichcar_decrement()
    {
    }
    public void save_data()
    {

    }

    public void bye_data()
    {

    }
    public void backtomainmenu()
    {
        cam1.Priority = 19;
        cam2.Priority = 9;
        cam3.Priority = 9;
        cam4.Priority = 9;

    }
    public void gotosettings()
    {
        cam1.Priority = 9;
        cam2.Priority = 19;
        cam3.Priority = 9;
        cam4.Priority = 9;
    }

    public void gotogarrage()
    {
        cam1.Priority = 9;
        cam2.Priority = 9;
        cam3.Priority = 19;
        cam4.Priority = 9;
    }
    public void gotolevel()
    {
        cam1.Priority = 9;
        cam2.Priority = 9;
        cam3.Priority = 9;
        cam4.Priority = 19;
    }

    //play


    //garrage

        




    //settings



    //quit
    public void quit()
    {
        gameManager.Quit();
    }

  //level

    public void levelgoing(int index)
    {
        gameManager.loadscene(index);
    }
}

