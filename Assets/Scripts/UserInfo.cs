using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class UserInfo : MonoBehaviour {

	public GameObject WallHeightDisplay;
	public Slider WallHeightSlider;
	public GameObject WallWidthDisplay;
	public Slider WallWidthSlider;


	public GameObject TileHeightDisplay;
	public Slider TileHeightSlider;
	public GameObject TileWidthDisplay;
	public Slider TileWidthSlider;

	public Canvas canvas;
	 GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
	 Sprite image;
    List<RaycastResult> results = new List<RaycastResult>();

	private void Update()
	{
		WallHeightDisplay.GetComponent<TMP_InputField>().text=string.Format("{0:N0}",WallHeightSlider.value);
		WallWidthDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N0}",WallWidthSlider.value);

		TileHeightDisplay.GetComponent<TMP_InputField>().text=string.Format("{0:N0}",TileHeightSlider.value);
		TileWidthDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N0}",TileWidthSlider.value);
	
	}
	 private void Awake()
    {

        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }
	void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            m_Raycaster.Raycast(m_PointerEventData, results);
            CellSelected();
        }

    }
    void CellSelected()
    {
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.tag == "ColorTile")
            {
                image = result.gameObject.GetComponent<Image>().sprite;
				
            }
        }
    }

}

