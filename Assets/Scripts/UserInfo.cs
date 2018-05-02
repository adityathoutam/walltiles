using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class UserInfo : MonoBehaviour {


    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject BottomWall;

    public GameObject RoomMaker;

	public GameObject WallHeightDisplay;
	public Slider WallHeightSlider;
	public GameObject WallWidthDisplay;
	public Slider WallWidthSlider;


	public GameObject TileHeightDisplay;
	public Slider TileHeightSlider;
	public GameObject TileWidthDisplay;
	public Slider TileWidthSlider;

	public GameObject GroutDisplay;
	public Slider GroutSlider;

	public Canvas canvas;
	 GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
	 Sprite TileImage;
	 Material TileMaterial;

	 Sprite GroutImage;
	 Material GroutMaterial;
	 public Material[] materialList;
    List<RaycastResult> results = new List<RaycastResult>();

	private void Update()
	{
		TileImageSelected();
		GroutImageSelected();
		
		WallHeightDisplay.GetComponent<TMP_InputField>().text=string.Format("{0:N0}",WallHeightSlider.value);
		WallWidthDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N0}",WallWidthSlider.value);

		TileHeightDisplay.GetComponent<TMP_InputField>().text=string.Format("{0:N0}",TileHeightSlider.value);
		TileWidthDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N0}",TileWidthSlider.value);

		GroutDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N2}",GroutSlider.value);
    
	}
	 private void Awake()
    {

        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();


        RoomMaker.GetComponent<RoomMaker>().scale.x =2;

        GameObject go =Instantiate(RoomMaker);
       
      
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
                TileImage = result.gameObject.GetComponent<Image>().sprite;
				
            }
			if (result.gameObject.tag == "GroutColor")
            {
                GroutImage = result.gameObject.GetComponent<Image>().sprite;
				
            }
        }
    }
	void TileImageSelected()
    {
        if (TileImage != null)
        {
            if (TileImage.name == "Tile_A")
                TileMaterial = materialList[0];
                
            else if (TileImage.name == "Tile_B")
                TileMaterial = materialList[1];

            else if (TileImage.name == "Tile_C")
                TileMaterial = materialList[2];

            else if (TileImage.name == "Tile_D")
                TileMaterial = materialList[3];

            else if (TileImage.name == "Tile_E")
                TileMaterial = materialList[4];

            else if (TileImage.name == "Tile_F")
                TileMaterial = materialList[5];

            else if (TileImage.name == "Tile_G")
                TileMaterial = materialList[6];

            else if (TileImage.name == "Tile_H")
                TileMaterial = materialList[7];

            else if (TileImage.name == "Tile_I")
                TileMaterial = materialList[8];

            else if (TileImage.name == "Tile_J")
                TileMaterial = materialList[9];
        }
        else
        TileMaterial = materialList[0];

    }
	void GroutImageSelected()
    {
        if (GroutImage != null)
        {
            if (GroutImage.name == "Tile_A")
                GroutMaterial = materialList[0];
                
            else if (GroutImage.name == "Tile_B")
                GroutMaterial = materialList[1];

            else if (GroutImage.name == "Tile_C")
                GroutMaterial = materialList[2];

            else if (GroutImage.name == "Tile_D")
                GroutMaterial = materialList[3];

            else if (GroutImage.name == "Tile_E")
                GroutMaterial = materialList[4];

            else if (GroutImage.name == "Tile_F")
                GroutMaterial = materialList[5];

            else if (GroutImage.name == "Tile_G")
                GroutMaterial = materialList[6];

            else if (GroutImage.name == "Tile_H")
                GroutMaterial = materialList[7];

            else if (GroutImage.name == "Tile_I")
                GroutMaterial = materialList[8];

            else if (GroutImage.name == "Tile_J")
                GroutMaterial = materialList[9];
        }
        else
        GroutMaterial = materialList[0];

    }

}

