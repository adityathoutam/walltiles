using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    Vector3 Touchposition;
    float swipeX = 50f;
    public GameObject Panel;

    void Start ()
    {
        Panel.SetActive(true);
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
                Panel.GetComponent<RectTransform>().position = new Vector3(400, 150);
            }
        }
    }

	void Update ()
    {
        SwipeManager();
    }
}
