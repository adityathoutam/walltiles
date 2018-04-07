using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadCreator : MonoBehaviour
{
    public GameObject WallPre;

    WallCreation WallCreationScript;
    public float TileSizeX, TileSizeY, WallSizeX, WallSizeY, RowWidth, ColoumnWidth;

     public Slider TileSizeXS, TileSizeYS, WallSizeXS, WallSizeYS, RowWidthS, ColoumnWidthS;
    public Text tTileSizeX, tTileSizeY, tWallSizeX, tWallSizeY, tRowWidth, tColoumnWidth;

    int count=0;

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


        InstantiateValues();
        if (Input.GetKeyDown(KeyCode.Space))
        {

           GameObject WallCreated =  Instantiate(WallPre) as GameObject;

        }


    }
}
