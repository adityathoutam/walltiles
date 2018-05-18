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

   
    public GameObject Wall_A_H,Wall_A_W;
    public GameObject Wall_B_H,Wall_B_W;
    public GameObject Wall_C_H,Wall_C_W;
    public GameObject Wall_D_H,Wall_D_W;
    public GameObject Tile_H,Tile_W;
    public GameObject Grout_H,Grout_W;

    
         public Button Wall_A_H_Plus,Wall_A_W_Plus;
         public Button Wall_A_H_Minus,Wall_A_W_Minus;
         public Button Wall_B_H_Plus,Wall_B_W_Plus;
         public Button Wall_B_H_Minus,Wall_B_W_Minus;
         public Button Wall_C_H_Plus,Wall_C_W_Plus;
         public Button Wall_C_H_Minus,Wall_C_W_Minus;
           public Button Wall_D_H_Plus,Wall_D_W_Plus;
           public Button Wall_D_H_Minus,Wall_D_W_Minus;
           public Button Tile_H_Plus,Tile_W_Plus;
           public Button Tile_H_Minus,Tile_W_Minus;
           public Button Grout_H_Plus,Grout_W_Plus;
           public Button Grout_H_Minus,Grout_W_Minus;
           
    public float Wall_A_H_Num,Wall_A_W_Num;
    public float Wall_B_H_Num,Wall_B_W_Num;
    public float Wall_C_H_Num,Wall_C_W_Num;
    public float Wall_D_H_Num,Wall_D_W_Num;
    public float Tile_H_Num,Tile_W_Num;
    public float Grout_H_Num,Grout_W_Num;
private void Start()
{
    Wall_A_H_Plus.onClick.AddListener(delegate{ButtonHandler(ref Wall_A_H_Num,5,20,1);});
    Wall_A_H_Minus.onClick.AddListener(delegate{ButtonHandler(ref Wall_A_H_Num,5,20,-1 );});
    Wall_A_W_Plus.onClick.AddListener(delegate{ButtonHandler(ref Wall_A_W_Num,5,20,1);});
    Wall_A_W_Minus.onClick.AddListener(delegate{ButtonHandler(ref Wall_A_W_Num,5,20,-1);});    

     Wall_B_H_Plus.onClick.AddListener(delegate{ButtonHandler(ref Wall_B_H_Num,5,20,1);});
    Wall_B_H_Minus.onClick.AddListener(delegate{ButtonHandler(ref Wall_B_H_Num,5,20,-1 );});
    Wall_B_W_Plus.onClick.AddListener(delegate{ButtonHandler(ref Wall_B_W_Num,5,20,1);});
    Wall_B_W_Minus.onClick.AddListener(delegate{ButtonHandler(ref Wall_B_W_Num,5,20,-1);});

     Wall_C_H_Plus.onClick.AddListener(delegate{ButtonHandler(ref Wall_C_H_Num,5,20,1);});
    Wall_C_H_Minus.onClick.AddListener(delegate{ButtonHandler(ref Wall_C_H_Num,5,20,-1 );});
    Wall_C_W_Plus.onClick.AddListener(delegate{ButtonHandler(ref Wall_C_W_Num,5,20,1);});
    Wall_C_W_Minus.onClick.AddListener(delegate{ButtonHandler(ref Wall_C_W_Num,5,20,-1);});

     Wall_D_H_Plus.onClick.AddListener(delegate{ButtonHandler(ref Wall_D_H_Num,5,20,1);});
    Wall_D_H_Minus.onClick.AddListener(delegate{ButtonHandler(ref Wall_D_H_Num,5,20,-1 );});
    Wall_D_W_Plus.onClick.AddListener(delegate{ButtonHandler(ref Wall_D_W_Num,5,20,1);});
    Wall_D_W_Minus.onClick.AddListener(delegate{ButtonHandler(ref Wall_D_W_Num,5,20,-1);});


    Tile_H_Plus.onClick.AddListener(delegate{ButtonHandler(ref Tile_H_Num,1,5,1);});
    Tile_H_Minus.onClick.AddListener(delegate{ButtonHandler(ref Tile_H_Num,1,5,-1 );});
    Tile_W_Plus.onClick.AddListener(delegate{ButtonHandler(ref Tile_W_Num,1,5,1);});
    Tile_W_Minus.onClick.AddListener(delegate{ButtonHandler(ref Tile_W_Num,1,5,-1);});

    Grout_H_Plus.onClick.AddListener(delegate{ButtonHandler(ref Grout_H_Num,0.01f,0.1f,0.01f);});
    Grout_H_Minus.onClick.AddListener(delegate{ButtonHandler(ref Grout_H_Num,0.01f,0.1f,0.01f );});
    Grout_W_Plus.onClick.AddListener(delegate{ButtonHandler(ref Grout_W_Num,0.01f,0.1f,0.01f);});
    Grout_W_Minus.onClick.AddListener(delegate{ButtonHandler(ref Grout_W_Num,0.01f,0.1f,0.01f);});

 
}


 public void  ButtonHandler(ref float a, float min,float max,float increment )
    {
            a = Mathf.Clamp(a+increment,min,max);
    }
  
  
    public Image tileImage;
    public Text WallArea_A;
    public Text WallArea_B;
    public Text WallArea_C;
    public Text WallArea_D;
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

    public GameObject WallHeightDisplay;
	public Slider WallHeightSlider;
	public GameObject WallWidthDisplay;
	public Slider WallWidthSlider;

	public GameObject GroutDisplay;
	public Slider GroutSlider;

	public Canvas canvas;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
	public Sprite TileImage;
	public Material TileMaterial;

    public Material[] TilematerialList;
    public Material[] GroutMaterialList;

   public Sprite GroutImage;
	public Material GroutMaterial;
    List<RaycastResult> results = new List<RaycastResult>();
    public GameObject CompletedRoom;
    RoomMaker[] roomMakerComponents;

   
   public int ThreeDBtnClick =0;

    public GameObject CanvasCamera;

    public GameObject SingleWallCreator;

    private void Update()
	{
		TileImageSelected();
		GroutImageSelected();


        Wall_A_H.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Wall_A_H_Num);
         Wall_A_W.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Wall_A_W_Num);

          Wall_B_H.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Wall_B_H_Num);
         Wall_B_W.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Wall_B_W_Num);

          Wall_C_H.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Wall_C_H_Num);
         Wall_C_W.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Wall_C_W_Num);

          Wall_D_H.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Wall_D_H_Num);
         Wall_D_W.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Wall_D_W_Num);
        
        Tile_H.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Tile_H_Num);
        Tile_W.GetComponent<TMP_InputField>().text = string.Format("{0:N0}", Tile_W_Num);

        Grout_H.GetComponent<TMP_InputField>().text = string.Format("{0:N2}", Grout_H_Num);
        Grout_W.GetComponent<TMP_InputField>().text = string.Format("{0:N2}", Grout_W_Num);
        
        
        // PriceDetails();
        


        // WallHeightDisplay.GetComponent<TMP_InputField>().text=string.Format("{0:N0}",WallHeightSlider.value);
		// WallWidthDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N0}",WallWidthSlider.value);

		// TileHeightDisplay.GetComponent<TMP_InputField>().text=string.Format("{0:N0}",TileHeightSlider.value);
		// TileWidthDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N0}",TileWidthSlider.value);

		// GroutDisplay.GetComponent<TMP_InputField>().text =string.Format("{0:N2}",GroutSlider.value);
	}

    void PriceDetails()
    {
        count = System.Math.Round(WallHeightSlider.value/TileHeightSlider.value * WallWidthSlider.value/TileWidthSlider.value, 0, System.MidpointRounding.AwayFromZero); 
        NoOfTiles.text = " " + count;
        TileSize.text = " " + string.Format("{0:N0}", TileHeightSlider.value);

        WallArea_A.text = " " + Wall_A_H_Num * Wall_A_W_Num;
        WallArea_B.text = " " + Wall_B_H_Num * Wall_B_W_Num;
        WallArea_C.text = " " + Wall_C_H_Num * Wall_C_W_Num;
        WallArea_D.text = " " + Wall_D_H_Num * Wall_D_W_Num;

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

      // Wall_A_H = WallHeightDisplay.GetComponent<TMP_InputField>().text;
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
            Camera.main.fieldOfView=60f;
            if(SingleWallCreator.GetComponent<SingleWallCreator>().Wall!=null)
            Destroy(SingleWallCreator.GetComponent<SingleWallCreator>().Wall);
                 CanvasCamera.SetActive(false);
               StartCoroutine(StartCounting());
               ThreeDBtnClick++;
               return;
        }

        if(ThreeDBtnClick==1)
        {
                Destroy(CompletedRoom);
               
                  CanvasCamera.SetActive(true);
                  ThreeDBtnClick=0;
        }
       
    }
   
public void DestoryYhreeDWall()
{
    if(CompletedRoom!=null)
    {
    Destroy(CompletedRoom);
    }

}
  
    IEnumerator StartCounting()
    {
        if(CompletedRoom==null)
        {
        CompletedRoom =Instantiate(RoomMaker) as GameObject;
         roomMakerComponents = CompletedRoom.GetComponents<RoomMaker>();
        
        for(int i=0;i<roomMakerComponents[0].Tiles.Count;i++)
        {
            roomMakerComponents[0].Tiles[i].GetComponent<Renderer>().material =TileMaterial;
            roomMakerComponents[1].Tiles[i].GetComponent<Renderer>().material=TileMaterial;
            roomMakerComponents[2].Tiles[i].GetComponent<Renderer>().material =TileMaterial;

            roomMakerComponents[0].Wall.GetComponent<Renderer>().material = GroutMaterial;
            roomMakerComponents[1].Wall.GetComponent<Renderer>().material = GroutMaterial;
            roomMakerComponents[2].Wall.GetComponent<Renderer>().material = GroutMaterial;

        }
        yield return new WaitForSeconds(1);

            roomMakerComponents[0].Wall.transform.position = new Vector3(-3.5f,0,0);
            roomMakerComponents[1].Wall.transform.position = new Vector3(3.5f,0,0);
            roomMakerComponents[2].Wall.transform.position = new Vector3(0,-4.8f,-4.2f);
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
            if (TileImage.name == "Tile1")
                TileMaterial = TilematerialList[0];
                
            else if (TileImage.name == "Tile2")
                TileMaterial = TilematerialList[1];

            else if (TileImage.name == "Tile3")
                TileMaterial = TilematerialList[2];

            else if (TileImage.name == "Tile4")
                TileMaterial = TilematerialList[3];

            else if (TileImage.name == "Tile5")
                TileMaterial = TilematerialList[4];

            else if (TileImage.name == "Tile6")
                TileMaterial = TilematerialList[5];

            else if (TileImage.name == "Tile7")
                TileMaterial = TilematerialList[6];

            else if (TileImage.name == "Tile8")
                TileMaterial = TilematerialList[7];

            else if (TileImage.name == "Tile9")
                TileMaterial = TilematerialList[8];

            else if (TileImage.name == "Tile10")
                TileMaterial = TilematerialList[9];
        }
        else
        TileMaterial = TilematerialList[0];
    }

	void GroutImageSelected()
    {
        if (GroutImage != null)
        {
            if (GroutImage.name == "Grout1")
                GroutMaterial = GroutMaterialList[0];
                
            else if (GroutImage.name == "Grout2")
                GroutMaterial = GroutMaterialList[1];

            else if (GroutImage.name == "Grout3")
                GroutMaterial = GroutMaterialList[2];

            else if (GroutImage.name == "Grout4")
                GroutMaterial = GroutMaterialList[3];

            else if (GroutImage.name == "Grout5")
                GroutMaterial = GroutMaterialList[4];

            else if (GroutImage.name == "Grout6")
                GroutMaterial = GroutMaterialList[5];

            else if (GroutImage.name == "Grout7")
                GroutMaterial = GroutMaterialList[6];

            else if (GroutImage.name == "Grout8")
                GroutMaterial = GroutMaterialList[7];
        }
        else
        GroutMaterial = GroutMaterialList[0];
    }

}

