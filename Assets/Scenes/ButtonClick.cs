using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    private void Start()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(true);
        Panel3.SetActive(false);

    }
    public void View1()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
    }
    public void View2()
    {
        Panel2.SetActive(true);
        Panel1.SetActive(false);
        Panel3.SetActive(false);

    }

    public void PriceView()
    {
        Panel3.SetActive(true);
        Panel2.SetActive(false);
        Panel1.SetActive(false);
    }


}
