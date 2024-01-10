using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class vr_cam_control : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
  public  Image camcontrolarea;
     [SerializeField] CinemachineFreeLook vcam;
   // [SerializeField] CinemachineVirtualCamera vcam;
    string strmouseX = "Mouse X", strMouseY = "Mouse Y";
    // Start is called before the first frame update
    void Start()
    {
       camcontrolarea = GetComponent<Image>();  
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            camcontrolarea.rectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out Vector2 posout)) 
        {
           vcam.m_XAxis.m_InputAxisName=strmouseX;
            vcam.m_YAxis.m_InputAxisName =strMouseY;
           
        }
      
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        vcam.m_XAxis.m_InputAxisName = null;
        vcam.m_YAxis.m_InputAxisName = null;
        vcam.m_XAxis.m_InputAxisValue = 0;
        vcam.m_YAxis.m_InputAxisValue= 0;
    }
}
