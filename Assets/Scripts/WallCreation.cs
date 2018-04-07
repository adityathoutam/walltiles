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
    public GameObject Quad;
     GameObject QuadPrefab;

    public Vector3 cubeScale;
    public Vector3 QuadScale;


    Vector2 TopLeft, TopRight;
    int QuadWidth, QuadHeight, QuadArea;

    List<GameObject> Tiles = new List<GameObject>();

    void Awake()
    {
        QuadPrefab = Instantiate(Quad);

        QuadPrefab.transform.position = Vector3.zero;
        TilePrefab.transform.localScale = cubeScale;
        QuadPrefab.transform.localScale = QuadScale;

        QuadPrefab.AddComponent<BoxCollider>();
        boxCollider = QuadPrefab.GetComponent<BoxCollider>();
        QuadWidth = (int)QuadPrefab.transform.localScale.x;
        QuadHeight = (int)QuadPrefab.transform.localScale.y;
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
        for (int i = 0; i < QuadArea - 1; i++)
        {
            SetPosition(i);
        }

    }
    void SetPosition(int i)
    {

        int k = QuadWidth/(int)scale.x;

        for (int j = k; j < QuadArea; j = j + k)
        {
            Tiles[j].transform.position = new Vector3(Tiles[j - k].transform.position.x,
                                                Tiles[j - k].transform.position.y - scale.y - ColoumnWidth, 0);
            Tiles[j].transform.localScale = Tiles[j-k].transform.localScale;
        }

          Tiles[i + 1].transform.localScale = Tiles[i].transform.localScale;
          Tiles[i + 1].transform.position = Tiles[i].transform.position;

        Tiles[i + 1].transform.position = new Vector3(Tiles[i + 1].transform.position.x + scale.x + RowWidth,
                                                Tiles[i + 1].transform.position.y,
                                                Tiles[i + 1].transform.position.z);





        if(Tiles[i].transform.position.x>TopRight.x)
            Tiles[i].SetActive(false);
        if(Tiles[i].transform.position.y<-boxCollider.bounds.max.y + scale.y / 2)
         Tiles[i].SetActive(false);


    }
}