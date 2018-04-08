using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject Wall_Switch;
    public GameObject Tile_Switch;
    bool Wall_Switch_T,Tile_Switch_T;



    Vector3 Touchposition;
    RectTransform rect,rect2;
    float swipeX = 150f;
    float swipeY = 150f;
    public GameObject Panel,Panel2;
    Vector2 deltaSwipe;

    void Start()
    {
        Panel.SetActive(true);
        Panel2.SetActive(true);
        rect = Panel.GetComponent<RectTransform>();
        rect2 = Panel2.GetComponent<RectTransform>();


        SetRect(rect, 225, 862, 195, -665);
        SetRect(rect2, -1795, 90, 2215, 60);
    }

    void SwipeManager()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Touchposition = Input.mousePosition;
        }


    if(Touchposition.x>Screen.width/2)
    {
        if (Input.GetMouseButtonUp(0))
        {
             deltaSwipe = Touchposition - Input.mousePosition;

        if(Tile_Switch_T)
        {
            if (Mathf.Abs(deltaSwipe.y) > swipeY)
            {
                if (deltaSwipe.y < 0)
                {
                    SetRect(rect, 180, 90, 240, 60);
                }
                else
                {
                    SetRect(rect, 225, 862, 195, -665);
                }
            }

        }
    }
    }
    if(Touchposition.x<Screen.width/2)
    {
        if (Input.GetMouseButtonUp(0))
        {
            deltaSwipe = Touchposition - Input.mousePosition;
            if (Wall_Switch_T)
            {
                if (Mathf.Abs(deltaSwipe.x) > swipeX)
                {
                    if (deltaSwipe.x < 0)
                    {
                        SetRect(rect2, 180, 90, 240, 60);
                    }
                    else
                    {
                        SetRect(rect2, -1795, 90, 2215, 60);
                    }
                }
            }
        }
    }
    }

    public static void SetRect(RectTransform rectTransform, float left, float top, float right, float bottom)
    {
        rectTransform.offsetMin = new Vector2(left, bottom);
        rectTransform.offsetMax = new Vector2(-right, -top);
    }
    void Update()
    {
        Wall_Switch_T = Wall_Switch.GetComponent<Switch>().isOn;
        Tile_Switch_T = Tile_Switch.GetComponent<Switch>().isOn;
       SwipeManager();

    }
}
