using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour
{

    public bool CameraMan;

   // public Camera mainCamera;
    public Camera ZoomCamera;

    private bool CamSwitch;
    
    void Awake()
    {
         CamSwitch = false;
        
    }

    // public void SwitchZoom()
    // {
    //     CamSwitch = !CamSwitch;
    //     mainCamera.gameObject.SetActive(!CamSwitch);
    //     ZoomCamera.gameObject.SetActive(CamSwitch);
      
    // }

    private bool firstClick = false, secondClick = false;

  
    public void OnClicked()
    {
       

       if (firstClick)
       {
           First();
           firstClick = false;
       }
       else if(secondClick)
       {
           Second();
           secondClick = false;
       }
       else
       {
           Third();
           firstClick = true;
           secondClick = true;
       }
       
    }

    public void First()
    {
      ZoomCamera.fieldOfView =30;
    }

    public void Second()
    {
       ZoomCamera.fieldOfView = 20;
    }

    public void Third()
    {
       ZoomCamera.fieldOfView = 10;
    }

}
