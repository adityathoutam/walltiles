using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour
{

    public bool CameraMan;
    public GameObject GameManager;


    private bool firstClick = false, secondClick = false;

    void Update()

    {
        CameraMan = GameManager.GetComponent<QuadCreator>().CameraMan;
    }
    public void OnClicked()
    {
       if(CameraMan)
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
    }

    public void First()
    {
       Camera.main.fieldOfView =30;
    }

    public void Second()
    {
       Camera.main.fieldOfView = 20;
    }

    public void Third()
    {
       Camera.main.fieldOfView = 10;
    }

}
