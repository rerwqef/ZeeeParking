using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

   GameObject losepannel;

     void Start()
    {
        if (GameObject.FindGameObjectWithTag("LosePannel") == null)
        {
            print("Cant find losepannel");
        }
    
        losepannel = GameObject.FindGameObjectWithTag("LosePannel");
        losepannel.SetActive(false);
       
    }
    public void gameover()
    {
     
        losepannel.SetActive(true);
    //    transition.SetActive(true);
       // Invoke("new0", 1.3f);

    }
}
