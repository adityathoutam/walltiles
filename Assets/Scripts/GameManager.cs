using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject HamBurgerPanel;
	
	void Awake () {
		HamBurgerPanel.SetActive(false);
	}
	
	public void HamBurgerPanelSet()
	{
	HamBurgerPanel.SetActive(true);

	}


}
