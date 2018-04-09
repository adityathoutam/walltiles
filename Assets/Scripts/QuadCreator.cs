using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class QuadCreator : MonoBehaviour
{
    public GameObject WallPre;
    public GameObject ColorPicker;
    public GameObject HalfTiles;
    public Camera camera;
    public Canvas canvas;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    List<RaycastResult> results = new List<RaycastResult>();
    public Material[] materialList;

    bool UserClicked = false;
    GameObject WallCreated;
    WallCreation WallCreationScript;

    Sprite image;
    Material material;

    public GameObject AllTilesMaterial;

    public float TileSizeX, TileSizeY, WallSizeX, WallSizeY, RowWidth, ColoumnWidth;

    public Slider TileSizeXS, TileSizeYS, WallSizeXS, WallSizeYS, RowWidthS, ColoumnWidthS;
    public Text tTileSizeX, tTileSizeY, tWallSizeX, tWallSizeY, tRowWidth, tColoumnWidth;
    RaycastHit hit;
    Ray ray;
    private void Awake()
    {

        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }
    void InstantiateValues()
    {
        WallCreationScript = WallPre.GetComponent<WallCreation>();
        WallCreationScript.cubeScale.x = TileSizeX;
        WallCreationScript.cubeScale.y = TileSizeY;
        WallCreationScript.QuadScale.x = WallSizeX;
        WallCreationScript.QuadScale.y = WallSizeY;
        WallCreationScript.RowWidth = RowWidth;
        WallCreationScript.ColoumnWidth = ColoumnWidth;

        RowWidth = RowWidthS.value;
        tRowWidth.text = " " + RowWidthS.value;

        ColoumnWidth = ColoumnWidthS.value;
        tColoumnWidth.text = " " + ColoumnWidthS.value;

        WallSizeX = WallSizeXS.value;
        tWallSizeX.text = " " + WallSizeXS.value;

        WallSizeY = WallSizeYS.value;
        tWallSizeY.text = " " + WallSizeYS.value;

        TileSizeX = TileSizeXS.value;
        tTileSizeX.text = " " + TileSizeXS.value;

        TileSizeY = TileSizeYS.value;
        tTileSizeY.text = " " + TileSizeYS.value;
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
    void ImageSelected()
    {
        if (image != null)
        {
            if (image.name == "Tile_A")
                material = materialList[0];

            else if (image.name == "Tile_B")
                material = materialList[1];
            else if (image.name == "Tile_C")
                material = materialList[2];
            else if (image.name == "Tile_D")
                material = materialList[3];
            else if (image.name == "Tile_E")
                material = materialList[4];
            else if (image.name == "Tile_F")
                material = materialList[5];
            else if (image.name == "Tile_G")
                material = materialList[6];
            else if (image.name == "Tile_H")
                material = materialList[7];
            else if (image.name == "Tile_I")   
                material = materialList[8];
            else if (image.name == "Tile_J")
                material = materialList[9];


        }
        
    }
    private void Update()
    {
        Color QuadColor = ColorPicker.GetComponent<ColorPicker>().SelectedColor;
        Material mat = AllTilesMaterial.GetComponent<Renderer>().material;

        ImageSelected();
        ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit.gameObject.tag == "ATM")
                {
                   // Debug.Log("kik");
                    objectHit.GetComponent<Renderer>().material = material;
                }
            }
        }





        InstantiateValues();

        if (UserClicked)
        {
            if (WallCreated == null)
            {
                WallCreated = Instantiate(WallPre) as GameObject;
                UserClicked = false;
            }
            else
                Create();


        }


        if (WallCreated != null)
        {
            WallCreated.GetComponent<WallCreation>().QuadColor = QuadColor;
            WallCreated.GetComponent<WallCreation>().HalfTiles = HalfTiles.GetComponent<Switch>().isOn;
            WallCreated.GetComponent<WallCreation>().material = mat;
        }
    }

    public void CreateWall()
    {
        UserClicked = true;
    }
    void Create()
    {
        Destroy(WallCreated.gameObject);
        UserClicked = true;
    }
}
