using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandiler : MonoBehaviour
{
    public int level = 4;
    public GameObject LevelPanel;
    public int star = 0;
    public Image[] levels;
    public Sprite ifEnabled;
    public Sprite ifDisabled;
    GameManager gm;

    public void Start()
    {
        gm = GameManager.Instance;
        LevelPanel.SetActive(false);
    }

    public void ShowLevelPannel()
    {
        LevelPanel.SetActive(true);
        for (int i = 0; i < levels.Length; i++)
        {
            if (i < level)
            {
               
                   levels[i].sprite = ifEnabled;
                
            }
            else
            {
                
                    levels[i].sprite = ifDisabled;
                
            }
        }
    }

    public void levelpannel_open()
    {
        LevelPanel.SetActive(true);
    }

    public void levelpannel_close()
    {
        LevelPanel.SetActive(false);
    }
}