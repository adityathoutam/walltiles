using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadCreator : MonoBehaviour
{
    public GameObject WallPre;
    public GameObject ColorPicker;
    public GameObject HalfTiles;


    bool UserClicked = false;
    GameObject WallCreated;
    WallCreation WallCreationScript;

    public GameObject AllTilesMaterial;

    public float TileSizeX, TileSizeY, WallSizeX, WallSizeY, RowWidth, ColoumnWidth;

    public Slider TileSizeXS, TileSizeYS, WallSizeXS, WallSizeYS, RowWidthS, ColoumnWidthS;
    public Text tTileSizeX, tTileSizeY, tWallSizeX, tWallSizeY, tRowWidth, tColoumnWidth;


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

    private void Update()
    {
        Color QuadColor = ColorPicker.GetComponent<ColorPicker>().SelectedColor;
        Material mat =AllTilesMaterial.GetComponent<Renderer>().material;


        InstantiateValues();

        if(UserClicked)
        {
            if(WallCreated==null)
            {
             WallCreated =  Instantiate(WallPre) as GameObject;
             UserClicked=false;
            }
            else
            Create();


        }


        if(WallCreated!=null)
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
        UserClicked=true;
    }
}
