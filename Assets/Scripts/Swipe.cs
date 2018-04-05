using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    Vector3 Touchposition;
    RectTransform rect;
    float swipeX = 150f;
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
                if (deltaSwipe.x > 0)
                {
                    rect.position = new Vector3(400, 150);
                    //rect.offsetMin = new Vector2(180,60);
                    //rect.offsetMax = new Vector2(-240,-90);
                    //SetRect(rect, 180, 90, 240, 60);
                }
                else
                {
                    rect.position = new Vector3(1150, 150);
                    //rect.offsetMin = new Vector2(2438,21);
                    //rect.offsetMax = new Vector2(-1869, -58);
                    //SetRect(rect, 2438, 58, 1869, 21);
                }
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
    }
}
