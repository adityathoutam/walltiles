using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour
{

    public bool CameraMan;

   // public Camera mainCamera;
    public Camera ZoomCamera;

   // private bool CamSwitch;
    float originalFOV;
    
    void Awake()
    {
        // CamSwitch = false;

         originalFOV =ZoomCamera.fieldOfView;
        
    }

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
      ZoomCamera.fieldOfView =+10f;;
    }

    public void Second()
    {
       ZoomCamera.fieldOfView = +20f;
    }

    public void Third()
    {
       ZoomCamera.fieldOfView = originalFOV;
    }

}
