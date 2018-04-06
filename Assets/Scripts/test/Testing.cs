using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour {

    public Slider slider;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        transform.localScale = new Vector3(slider.value, transform.localScale.y, transform.localScale.z);
	}
}
