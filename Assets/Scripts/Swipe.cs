﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    // public GameObject Wall_Switch;
    // public GameObject Tile_Switch;
    // bool Wall_Switch_T,Tile_Switch_T;

    private bool change = false;
    public Animator anim;

    Vector3 Touchposition;
    RectTransform rect,rect2;
    float swipeX = 150f;
    float swipeY = 150f;
    public GameObject Panel,Panel2;
    Vector2 deltaSwipe;

    void Start()
    {
        Time.timeScale = 1;
        anim = Panel2.GetComponent<Animator>();
        anim.enabled = false;


        Panel.SetActive(true);
        Panel2.SetActive(true);
        rect = Panel.GetComponent<RectTransform>();
        rect2 = Panel2.GetComponent<RectTransform>();


        SetRect(rect, -10,1318,10,-1318);
        SetRect(rect2, -2100, 10, 2100, 10);
    }
    

    public void MenuIN()
    {
        anim.enabled = true;

        anim.Play("MenuIN");

        change = true;

        Time.timeScale = 0;
    }

    public void MenuOUT()
    {

        change = false;

        anim.Play("MenuOUT");

        Time.timeScale = 1;
    }

    public void OnClickP2()
    {
        SetRect(rect2, -2100, 10, 2100, 10);
    }

    public void OnClickP1()
    {
        SetRect(rect, -10, 1318, 10, -1318);
    }

    public void Options()
    {
        if (!change)
            MenuIN();
        
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
               // MenuOUT();
            // deltaSwipe = Touchposition - Input.mousePosition;

        //// if(Tile_Switch_T)
        //// {
           if (Mathf.Abs(deltaSwipe.y) > swipeY)
           {
               if (deltaSwipe.y < 0)
               {
                   SetRect(rect, 10, 10, 10, 10);
               }
                
           // }

        }
    }

    }
    
    if(Touchposition.x<Screen.width/2)
    {
        if (Input.GetMouseButtonUp(0))
        {
            deltaSwipe = Touchposition - Input.mousePosition;
            // if (Wall_Switch_T)
            // {
                if (Mathf.Abs(deltaSwipe.x) > swipeX)
                {
                    if (deltaSwipe.x < 0)
                    {
                        SetRect(rect2, 10,10,10,10);
                    }

               // }
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
       // Wall_Switch_T = Wall_Switch.GetComponent<Switch>().isOn;
      //  Tile_Switch_T = Tile_Switch.GetComponent<Switch>().isOn;
       SwipeManager();

    }
}
