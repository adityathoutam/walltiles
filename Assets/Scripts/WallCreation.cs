using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallCreation : MonoBehaviour
{

    BoxCollider boxCollider;
    Vector2 scale;
    public float RowWidth,ColoumnWidth;
    public GameObject TilePrefab;
    public GameObject QuadPrefab;
    public GameObject []room;

     GameObject Quad;

    public Vector3 cubeScale;
    public Vector3 QuadScale;
    public Color QuadColor;

    public bool boolcamera;


    Vector2 TopLeft, TopRight;
    float QuadWidth, QuadHeight, QuadArea;

    public bool HalfTiles;


    List<GameObject> Tiles = new List<GameObject>();

    void Awake()
    {


       

            Quad = Instantiate(QuadPrefab) as GameObject;

            Quad.transform.parent = transform;



            TilePrefab.transform.localScale = cubeScale;
            Quad.transform.localScale = QuadScale;
            scale = TilePrefab.transform.localScale;
            boxCollider = Quad.GetComponent<BoxCollider>();
            QuadWidth = Quad.transform.localScale.x;
            QuadHeight = Quad.transform.localScale.y;
            QuadArea = QuadHeight / scale.y * QuadWidth / scale.x;



            Instantiate();
        
    }

    void Instantiate()
    {



        for (int i = 0; i < QuadArea+1; ++i)
        {
            GameObject go = Instantiate(TilePrefab, Vector3.zero, Quaternion.identity);
            go.transform.parent = Quad.transform.parent;

            Tiles.Add(go);
        }


        TopLeft = new Vector2(boxCollider.bounds.min.x + scale.x / 2,
                 -boxCollider.bounds.min.y - scale.y / 2);
        TopRight = new Vector2(boxCollider.bounds.max.x - scale.x / 2,
                  boxCollider.bounds.max.y - scale.y / 2);

        Tiles[0].transform.position = TopLeft;

    }


    void Update()
    {


        for (int i = 0; i < QuadArea; i++)
        {
            SetPosition(i);
            Tiles[i].transform.parent = Quad.transform;
        }
         Quad.GetComponent<Renderer>().material.color = QuadColor;

        if(Camera.main!=null)
        setFovForObject(Camera.main, this.gameObject);
    }
    void SetPosition(int i)
    {
        Tiles[0].transform.position = TopLeft;

        int k = (int)(QuadWidth/scale.x);

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





    }

    void setFovForObject(Camera camera, GameObject go)
    {
        Bounds bounds = getBounds(go);


        float fovY = GetFieldOfView(camera, go.transform, bounds.size.y);
        float fovX = GetFieldOfView(camera, go.transform, bounds.size.x)* ((float)camera.pixelHeight / camera.pixelWidth);

        camera.fieldOfView = Mathf.Max(fovY, fovX);
    }

    float GetFieldOfView(Camera cam, Transform g, float size)
    {


        Vector3 diff = g.position - cam.transform.position;
        float distance = Vector3.Dot(diff, cam.transform.forward);
        float angle = Mathf.Atan((size * .5f) / distance);
        return angle * 2f * Mathf.Rad2Deg;


    }

    public Bounds getBounds(GameObject go)
    {
        Renderer renderer = go.GetComponent<Renderer>();
        Bounds combinedBounds = new Bounds();
        Renderer[] renderers = go.GetComponentsInChildren<Renderer>();
        foreach (Renderer render in renderers)
        {
            if (render != renderer) combinedBounds.Encapsulate(render.bounds);
        }

        return combinedBounds;
    }
}


