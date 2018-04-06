using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallCreation : MonoBehaviour
{

    BoxCollider boxCollider;
    Vector2 scale;
    public float RowWidth;
    public float ColoumnWidth;
    public GameObject TilePrefab;

    public Slider Row;
    public Slider Coloumn;
    public Slider TileHeight;
    public Slider TileWidth;

    Vector2 TopLeft, TopRight;
    int QuadWidth, QuadHeight, QuadArea;

    List<GameObject> Tiles = new List<GameObject>();
    List<GameObject> ScalingTiles = new List<GameObject>();

    void Awake()
    {

        boxCollider = GetComponent<BoxCollider>();
        QuadWidth = (int)transform.localScale.x;
        QuadHeight = (int)transform.localScale.y;
        QuadArea = QuadHeight * QuadWidth;

        Instantiate();
    }

    void Instantiate()
    {
        for (int i = 0; i < QuadArea; i++)
        {
            GameObject go = Instantiate(TilePrefab, Vector3.zero, Quaternion.identity);
            Tiles.Add(go);
        }
        scale = Tiles[0].transform.localScale;

        TopLeft = new Vector2(boxCollider.bounds.min.x + scale.x / 2,
                 -boxCollider.bounds.min.y - scale.y / 2);
        TopRight = new Vector2(boxCollider.bounds.max.x - scale.x / 2,
                  boxCollider.bounds.max.y - scale.y / 2);

        Tiles[0].transform.position = TopLeft;

    }

    void Update()
    {
        RowWidth = Row.value;
        ColoumnWidth = Coloumn.value;


        TilePrefab.transform.localScale = new Vector3(TileWidth.value, TileHeight.value, TilePrefab.transform.localScale.z);


        for (int i = 0; i < QuadArea - 1; i++)
        {
            SetPosition(i);
        }

    }
    void SetPosition(int i)
    {

        for (int j = QuadWidth; j < QuadArea; j = j + QuadWidth)
        {
            Tiles[j].transform.position = new Vector3(Tiles[j - QuadWidth].transform.position.x,
                                                Tiles[j - QuadWidth].transform.position.y - scale.y - ColoumnWidth, 0);
            Tiles[j].transform.localScale = Tiles[j-QuadWidth].transform.localScale;
        }
         if(Tiles[i].transform.position.x<TopRight.x)
         {
        Tiles[i + 1].transform.localScale = Tiles[i].transform.localScale;
        Tiles[i + 1].transform.position = Tiles[i].transform.position;

        Tiles[i + 1].transform.position = new Vector3(Tiles[i + 1].transform.position.x + scale.x + RowWidth,
                                                Tiles[i + 1].transform.position.y,
                                                Tiles[i + 1].transform.position.z);
         }
        //if(Tiles[i].transform.position.x>TopRight.x)
          //  Tiles[i].SetActive(false);
        //if(Tiles[i].transform.position.y<-boxCollider.bounds.max.y)
         //Tiles[i].SetActive(false);


    }
}