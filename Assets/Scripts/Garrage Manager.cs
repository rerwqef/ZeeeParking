using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GarrageManager : MonoBehaviour
{
    public GameObject[] cars;
    public Button preBtn;
    public Button nextBtn;
    public Button save;
    public Button buy;
    public Text tmp;
    public Button UnselectCar;
    public GameManager manager;
    public vr_cam_control vr;
    public int currentIndex = 0;
    public bool useblecarinde=true;
    
    private void Start()
    {
        manager = GameManager.Instance;
        currentIndex = manager.carindex;
        UpdateButtons();
        SwitchTab();
    }

    public void Pre()
    {
        SetIndex(currentIndex - 1);
      
    }

    public void Next()
    {
        SetIndex(currentIndex + 1);
     

    }
    public void setindexHelper()
    {
        SetIndex(currentIndex);
    }
     void SetIndex(int newIndex)
    {
        currentIndex = Mathf.Clamp(newIndex, 0, cars.Length - 1);
        SwitchTab();
        UpdateButtons();
      
    }

    private void SwitchTab()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == currentIndex);
        }
        
        if (manager.Buiedcars_num >currentIndex)
        {
            SaveCarBTNEnable(true);
            BuyCarBtnEnable(false);
            unselectCAR(false);
           if (currentIndex == manager.carindex&& useblecarinde==false)
        {
                unselectCAR(true);
            }
        }
        else if (manager.Buiedcars_num <=currentIndex)
        {
            BuyCarBtnEnable(true);
            SaveCarBTNEnable(false);
            unselectCAR(false);
        }
    }
    public void SaveCarBTNEnable(bool m)
    {
        save.gameObject.SetActive(m);
        if (m)
        {
            vr.iSrOTATABLE = false;
        }
        
    }
    public void unselectCAR(bool m)
    {
      UnselectCar.gameObject.SetActive(m);
        if (m)
        {
            vr.iSrOTATABLE = true;
            preBtn.gameObject.SetActive(false);
            nextBtn.gameObject.SetActive(false);
            useblecarinde = true;
        }
        else
        {
            vr.iSrOTATABLE = false;
            useblecarinde = false;
          //  preBtn.gameObject.SetActive(true);
          //  nextBtn.gameObject.SetActive(true);
            UpdateButtons();
        }
    }
    public void BuyCarBtnEnable(bool m)
    {
       buy.gameObject.SetActive(m);
        if (m)
        {
            vr.iSrOTATABLE = false;
        }
    }
    public void disbtn()
    {
        preBtn.gameObject.SetActive(false);
        nextBtn.gameObject.SetActive(false);
    }
    private void UpdateButtons()
    {
        preBtn.gameObject.SetActive(currentIndex > 0);
        nextBtn.gameObject.SetActive(currentIndex < cars.Length - 1);
    }

    public void SaveCurrentasstes()
    {
        manager.carindex = currentIndex;
        manager.car_datasaving();
    }

    public void SlectCar(bool m)
    {
        if (m)
        {
            save.gameObject.SetActive(false);
            UnselectCar.gameObject.SetActive(true);
            vr.iSrOTATABLE = true;
            preBtn.gameObject.SetActive(false);
            nextBtn.gameObject.SetActive(false);
        }
        else
        {
            save.gameObject.SetActive(true);
            UnselectCar.gameObject.SetActive(false);
            vr.iSrOTATABLE = false;
            preBtn.gameObject.SetActive(true);
            nextBtn.gameObject.SetActive(true);
        }
    }
}