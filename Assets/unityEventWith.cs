using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unityEventWith : MonoBehaviour
{
    public Image image;
    
    public static event Action show;
    void Start()
    {
        show += ImageSHow;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            show?.Invoke();
        }
    }

    public void ImageSHow()
    {
        image.gameObject.SetActive(true);
    }
}
