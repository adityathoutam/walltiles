using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour
{
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
        Camera.main.fieldOfView = 14;
    }

    public void Second()
    {
        Camera.main.fieldOfView = 40;
    }

    public void Third()
    {
        Camera.main.fieldOfView = 70;
    }

}
