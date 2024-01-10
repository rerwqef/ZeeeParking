using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class UiManger : MonoBehaviour
{
    public  GameManager gm;
    public TextMeshProUGUI coin_text;
    public GameObject Pause_pannel;
    public GameObject progress_pannel;
    public Slider progressSlider;
    public GameObject level_pannel;

    public GameObject losepannel;
    public GameObject wimningpannel;
    public GameObject levelpannel;
    // public CinemachineVirtualCamera cam1;

    //  public CinemachineVirtualCamera cam2;
    private void Start()
    {
        gm=GameManager.Instance;
    }
    //   public  PlayerCarController playerCarController;
    public void Update()
    {
        Debug.Log("UiManger: Update()");
        if (coin_text != null)
        {
            coin_text.text = gm.coin.ToString();
        }
        Debug.Log("UiManger: Update() - Exiting");
    }

    public void gotoscene(int index)
    {
        Debug.Log("UiManger: gotoscene(" + index + ")");
     gm.loadscene(index);
        Debug.Log("UiManger: gotoscene() - Exiting");
    }

    public void gotoNextscenewithlodingPannel(int index)
    {
        gm.LoadNextScene(-1);
    }

    public void open()
    {
        Debug.Log("UiManger: open()");
        level_pannel.SetActive(true);
        Debug.Log("UiManger: open() - Exiting");
    }

    public void close()
    {
        Debug.Log("UiManger: close()");
        level_pannel.SetActive(false);
        Debug.Log("UiManger: close() - Exiting");
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
    }
    public void restart()
    {
        gm.RestartGame();
    }
   public void levelpannel_open()
    {
        levelpannel.SetActive(true);
    }
    public void levelpannel_close()
    {
        levelpannel.SetActive(false);
    }
}