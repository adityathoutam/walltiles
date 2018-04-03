using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    Vector3 Touchposition;
    RectTransform rect;
    float swipeX = 50f;
    public GameObject Panel;

    void Start ()
    {
        Panel.SetActive(true);
        rect = Panel.GetComponent<RectTransform>();
	}

    void SwipeManager()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Touchposition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = Touchposition - Input.mousePosition;


            if (Mathf.Abs(deltaSwipe.x) > swipeX)
            {
                rect.position = new Vector3(400, 150);
                SetRect(rect,180,90,240,60);

            }
              
        }
    }
 public static void SetRect(RectTransform rectTransform, float left, float top, float right, float bottom)
{
    rectTransform.offsetMin = new Vector2(left, bottom);
    rectTransform.offsetMax = new Vector2(-right, -top);
}
	void Update ()
    {
        SwipeManager();
        Debug.Log(Touchposition.x-Input.mousePosition.x);
    }
}
