using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetttings : MonoBehaviour
{
    public vr_cam_control vr;
    public SteeringWheel steering;
    public bool vr_enable;
    public int currentsterinngvalue;
    GameManager gm;
    public void Awake()
    {
        
    }
    public void Start()
    {
     /*    gm=GameManager.Instance;
       // gm.currentsterinngvalue = currentsterinngvalue;
        steering.valueMultiplier = gm.currentsterinngvalue;
        if (gm.vr_enable == "true")
        {
            vr_enable = true;
        }else if(gm.vr_enable == "false")
        {
            vr_enable= false;
        }
       */
    }
  /*  public void applysettings()
    {
        gm.setcall();
    }*/
}
