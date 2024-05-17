using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Careffects : MonoBehaviour
{
    public PlayerCarController carController;
    public TrailRenderer[] tireMarks;
    public void Start()
    {
        carController = GetComponent<PlayerCarController>();

    }
    private void Update()
    {
        checkDrift();
    }
    public void checkDrift()
    {
        if (carController.breackking)
        {
            startEmitter();
        }
        else
        {
            stopEmitter();
        }
    }
    bool tiremarkFlg;
    private void startEmitter()
    {
  foreach(TrailRenderer t in tireMarks)
        {
            t.emitting = true;
        }
  tiremarkFlg=true;
    }

    private void stopEmitter()
    {
        foreach (TrailRenderer t in tireMarks)
        {
            t.emitting = false;
        }
        tiremarkFlg = false;
    }

 
}
