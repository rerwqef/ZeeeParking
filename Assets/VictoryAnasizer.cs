using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryAnasizer : MonoBehaviour
{
    public TimerScript time;
    public Speedometer speedometer;
    public int star=1;
    public Toggle[] starT;
    public Toggle[] MainSTAR;
    public int  Coin;
    public Text coinText;
    public void Start()
    {
        GameManager.onGameFinished += VictoryAnlized;
        GameManager.onGameFinished += mainstartON;
        GameManager.onGameFinished += COinUpdater;
       
    }
    public void VictoryAnlized()
    {
         On(0);
        Coin = 100;
        if (time.time >= 3f)
        {
            On(1);
            star++;
            Coin = 200;
        }
        if (speedometer.GoodSPeed)
        {
          On(2);

            star++;
            Coin = 300;
        }

    }

    void   On(int index)
    {
        starT[index].isOn = true;
   
    }
    void  mainstartON()
    {
        for (int  t=0;t<=star;t++)
        {
            if (t < MainSTAR.Length)
            {
                MainSTAR[t].isOn = true;
            }
          
        }
    }
    public void COinUpdater()
    {
        coinText.text = "+" + Coin;
    }
}
