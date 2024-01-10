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
    public TextMeshProUGUI tmp;

    public int text_value = 25000;
    public GameManager manager;

    private int currentIndex = 0;

    public int amout1 = 2500;
    public int amout2 = 50000;
    public int amout3 = 750000;

    private void Start()
    {
       manager=GameManager.Instance;
        Debug.Log("GarrageManager: Start()");
        tmp.text = text_value.ToString();
        currentIndex = manager.carindex;
        UpdateButtons();
        SwitchTab();
        save.interactable = true;
        buy.interactable = false;
        tmp.enabled = false;
        Debug.Log("GarrageManager: Start() - Exiting");
    }

    public void Pre()
    {
        Debug.Log("GarrageManager: Pre()");
        tmp.text = text_value.ToString();
        SetIndex(currentIndex - 1);
        if (manager.Buiedcars_num >= currentIndex)
        {
            Debug.Log("GarrageManager: Pre() - Case 2");
            save.interactable = true;
            buy.interactable = false;
            tmp.enabled = false;
        }
        else
        {
            Debug.Log("GarrageManager: Pre() - Case 3");
            save.interactable = false;
            buy.interactable = true;
            tmp.enabled = true;
        }
        Debug.Log("GarrageManager: Pre() - Exiting");
    }

    public void Next()
    {
        Debug.Log("GarrageManager: Next()");
        tmp.text = text_value.ToString();
        SetIndex(currentIndex + 1);
        Debug.Log("GarrageManager: Next() - Case 1");

        if (manager.Buiedcars_num >= currentIndex)
        {
            Debug.Log("GarrageManager: Next() - Case 2");
            save.interactable = true;
            buy.interactable = false;
            tmp.enabled = false;
        }
        else
        {
            Debug.Log("GarrageManager: Next() - Case 3");
            save.interactable = false;
            buy.interactable = true;
            tmp.enabled = true;

            if (manager.coin < text_value)
            {
                tmp.color = Color.red;
            }
            else
            {
                tmp.color = Color.green;
            }
        }
        Debug.Log("GarrageManager: Next() - Exiting");
    }

    private void SetIndex(int newIndex)
    {
        Debug.Log("GarrageManager: SetIndex(" + newIndex + ")");
        currentIndex = Mathf.Clamp(newIndex, 0, cars.Length - 1);
        SwitchTab();
        UpdateButtons();
        Debug.Log("GarrageManager: SetIndex() - Exiting");
    }

    private void SwitchTab()
    {
        Debug.Log("GarrageManager: SwitchTab()");
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == currentIndex);
        }
        Debug.Log("GarrageManager: SwitchTab() - Exiting");
    }

    private void UpdateButtons()
    {
        Debug.Log("GarrageManager: UpdateButtons()");
        preBtn.gameObject.SetActive(currentIndex > 0);
        nextBtn.gameObject.SetActive(currentIndex < cars.Length - 1);
        Debug.Log("GarrageManager: UpdateButtons() - Exiting");
    }

    public void SaveCurrentasstes()
    {
        Debug.Log("GarrageManager: SaveCurrentasstes()");
        manager.carindex = currentIndex;
        manager.car_datasaving();
        Debug.Log("GarrageManager: SaveCurrentasstes() - Exiting");
    }

    public void buyacar()
    {
        Debug.Log("GarrageManager: buyacar()");
        if (manager.coin > text_value)
        {
            save.interactable = true;
            buy.interactable = false;
            manager.coin -= text_value;
        }
        Debug.Log("GarrageManager: buyacar() - Exiting");
    }
}