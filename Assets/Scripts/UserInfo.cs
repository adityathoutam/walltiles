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

    public Image tileImage;
    public Text TileSize;
    public Text NoOfTiles;
    public Text Totalprice;
    public Text tileprice;
    public float Tileprice1x1 = 20;
    public float Tileprice2x2 = 50;
    public float Tileprice3x3 = 80;

    double count = 0;

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

    public Material[] materialList;

    Sprite GroutImage;
	Material GroutMaterial;
    List<RaycastResult> results = new List<RaycastResult>();
    GameObject go;
    RoomMaker[] roomMakerComponents;

    bool done =false;
    bool done2 =false;

   public int ThreeDBtnClick =0;

    public GameObject CanvasCamera;

    private void Update()
	{
		TileImageSelected();
		GroutImageSelected();


        PriceDetails();


        WallHeightDisplay.GetComponent<TMP_InputField>().text=string.Format("{0:N0}",WallHeightSlider.value);
		WallWidthDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N0}",WallWidthSlider.value);

		TileHeightDisplay.GetComponent<TMP_InputField>().text=string.Format("{0:N0}",TileHeightSlider.value);
		TileWidthDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N0}",TileWidthSlider.value);

		GroutDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N2}",GroutSlider.value);
	}

    void PriceDetails()
    {
          count = System.Math.Round(WallHeightSlider.value/TileHeightSlider.value * WallWidthSlider.value/TileWidthSlider.value, 0, System.MidpointRounding.AwayFromZero); 
        NoOfTiles.text = " " + count;
        TileSize.text = " " + string.Format("{0:N0}", TileHeightSlider.value);

      

        if ((TileHeightSlider.value >= 1 && TileWidthSlider.value >= 1) || (TileHeightSlider.value >= 1 && TileWidthSlider.value >= 2) || (TileHeightSlider.value >= 1 && TileWidthSlider.value >= 3))
        {
            tileprice.text = " " + Tileprice1x1;
            Totalprice.text = " " + count * Tileprice1x1;
        }
        if ((TileHeightSlider.value>=2 && TileWidthSlider.value >= 2) || (TileHeightSlider.value >= 2 && TileWidthSlider.value >= 3) || (TileHeightSlider.value >= 2 && TileWidthSlider.value >= 1))
        {
            tileprice.text = " " + Tileprice2x2;
            Totalprice.text = " " + count * Tileprice2x2;
        }
        if ((TileHeightSlider.value >= 3 && TileWidthSlider.value >= 3) || (TileHeightSlider.value >= 3 && TileWidthSlider.value >= 2) || (TileHeightSlider.value >= 3 && TileWidthSlider.value >= 1))
        {
            tileprice.text = " " + Tileprice3x3;
            Totalprice.text = " " + count * Tileprice3x3;
        }
        
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
    public void ThreeDRoom()
    {
        if(ThreeDBtnClick==0)
        {
        
                 CanvasCamera.SetActive(false);
               StartCoroutine(StartCounting());
               ThreeDBtnClick++;
               return;
        }

        if(ThreeDBtnClick==1)
        {
                Destroy(go);
                  CanvasCamera.SetActive(true);
                  ThreeDBtnClick=0;
        }
       
    }
   
public void DestoryYhreeDWall()
{
    if(go!=null)
    {
    Destroy(go);
    }

}
  
    IEnumerator StartCounting()
    {
        if(go==null)
        {
        go =Instantiate(RoomMaker) as GameObject;
         roomMakerComponents = go.GetComponents<RoomMaker>();
        
        for(int i=0;i<roomMakerComponents[0].Tiles.Count;i++)
        {
            roomMakerComponents[0].Tiles[i].GetComponent<Renderer>().material =TileMaterial;
            roomMakerComponents[1].Tiles[i].GetComponent<Renderer>().material=TileMaterial;
            roomMakerComponents[2].Tiles[i].GetComponent<Renderer>().material =TileMaterial;

            roomMakerComponents[0].Wall.GetComponent<Renderer>().material = GroutMaterial;
            roomMakerComponents[1].Wall.GetComponent<Renderer>().material = GroutMaterial;
            roomMakerComponents[2].Wall.GetComponent<Renderer>().material = GroutMaterial;

        }
        yield return new WaitForSeconds(2);

            roomMakerComponents[0].Wall.transform.position = new Vector3(-3.5f,0,0);
            roomMakerComponents[1].Wall.transform.position = new Vector3(3.5f,0,0);
            roomMakerComponents[2].Wall.transform.position = new Vector3(0,-5.1f,-4.2f);
            roomMakerComponents[0].Wall.transform.Rotate(0,-45,0);
            roomMakerComponents[1].Wall.transform.Rotate(0,45,0);
            roomMakerComponents[2].Wall.transform.Rotate(90,-45,0);

        yield return new WaitForSeconds(1);
        }
    }

    void CellSelected()
    {
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.tag == "ColorTile")
            {
                TileImage = result.gameObject.GetComponent<Image>().sprite;
                tileImage.sprite = TileImage;
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

