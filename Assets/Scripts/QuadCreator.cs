using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadCreator : MonoBehaviour
{
    public GameObject WallPre;
    GameObject WallCreated;
    WallCreation WallCreationScript;
    public float TileSizeX, TileSizeY, WallSizeX, WallSizeY, RowWidth, ColoumnWidth;


    void InstantiateValues()
    {
        WallCreationScript = WallPre.GetComponent<WallCreation>();
        WallCreationScript.cubeScale.x = TileSizeX;
        WallCreationScript.cubeScale.y = TileSizeY;
        WallCreationScript.QuadScale.x = WallSizeX;
        WallCreationScript.QuadScale.y = WallSizeY;
        WallCreationScript.RowWidth = RowWidth;
        WallCreationScript.ColoumnWidth = ColoumnWidth;

    }

    private void Update()
    {
        InstantiateValues();
        if (Input.GetKey(KeyCode.Space))
        {
            if (GameObject.Find("WallPre(Clone)").activeInHierarchy)
                Destroy(GameObject.Find("WallPre(Clone)"));
                WallCreated = Instantiate(WallPre);
                
        }
    }
}
