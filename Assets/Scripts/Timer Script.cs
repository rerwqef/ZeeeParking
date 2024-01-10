using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI timertext;
    public Image fill;
    public float max;
    GameManager gm;
    void Start()
    {

        time = max;
      gm=GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime; 
        timertext.text=""+(int)time;
        fill.fillAmount = time / max;
        if (time <= 0)
        {
            time = 0;
            while (true)
            {
                gm.failedingame();
                break;
            }
          
        }
    }
}
