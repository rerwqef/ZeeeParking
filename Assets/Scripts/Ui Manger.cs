using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using JetBrains.Annotations;

public class UiManger : MonoBehaviour
{
   [SerializeField] GameManager gm;
    public Text coin_text;
    public GameObject Pause_pannel;
    public GameObject progress_pannel;
    public Slider progressSlider;
    public GameObject losepannel;

    public GameObject levelpannel;
    public GameObject userNameEnteringPannel;

    public CinemachineFreeLook cam;

    public CinemachineVirtualCamera shootcam;


   public GameObject VictoryPannel;
    public GameObject transition;
    // public CinemachineVirtualCamera cam1;

    //  public CinemachineVirtualCamera cam2;
    private void Start()
    {
        gm = GameManager.Instance;
     //   GameManager.onGameFinished += OngameFinishedUi;
        if (gm.UserName == null)
        {
            //    userNameEnteringPannel.SetActive(true);
            Debug.Log("UserName Not addedd");

        }
        else
        {
            userNameEnteringPannel.SetActive(true);
        }
   /*     GameManager.onGaMeOver += gameover;*/
        if (VictoryPannel == null)
        {
            //VictoryPannel=FindObjectbyta
        }
    }
    //   public  PlayerCarController playerCarController;
    public void Update()
    {

        if (coin_text != null)
        {
            coin_text.text = gm.coin.ToString();
        }

    }
    public void RestartGame()
    {
        gm.RestartGame();
    }
    public void gotoscene(int index)
    {

        gm.loadscene(index);
    }

    public void gotoNextscenewithlodingPannel(int index)
    {
        gm.LoadNextScene(-1);
    }



    /* public void gotoCam1()
     {
         cam1.Priority = 19;

     }
     public void gotoCam2()
     {
         cam1.Priority = 9;
     }*/
    public void quit()
    {
        gm.Quit();
    }
    public void PAUSEGAME()
    {
        gm.Pause();
      //  gameover();
    }
    public void restart()
    {
        gm.RestartGame();
    }

/*    public void OngameFinishedUi()
    {
        if (VictoryPannel != null)
        {

            VictoryPannel.SetActive(true);
        }
        else
        {
            VictoryPannel = GameObject.FindGameObjectWithTag("VictoryPanel");
        }
        VictoryPannel.SetActive(true);
        //    Debug.Log("VictoryPannel pannel");
    }
   */

    public void new0()
    {
       // cam.Priority = 3;
     //   shootcam.m_Speed = 2;
    }

}