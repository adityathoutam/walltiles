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

     GameObject Quad;

    public Vector3 cubeScale;
    public Vector3 QuadScale;
    public Color QuadColor;


    Vector2 TopLeft, TopRight;
    int QuadWidth, QuadHeight, QuadArea;

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
        QuadWidth = (int)Quad.transform.localScale.x;
        QuadHeight = (int)Quad.transform.localScale.y;
        QuadArea = QuadHeight/(int)scale.y* QuadWidth/(int)scale.x;

        Instantiate();

       

        //float cameraDistance = 2.0f; // Constant factor
        //Vector3 objectSizes = boxCollider.bounds.max - boxCollider.bounds.min;
        //float objectSize = Mathf.Max(objectSizes.x, objectSizes.y, objectSizes.z);
        //float cameraView = 2.0f * Mathf.Tan(0.5f * Mathf.Deg2Rad * Camera.main.fieldOfView); // Visible height 1 meter in front
        //float distance = cameraDistance * objectSize / cameraView; // Combined wanted distance from the object
        //distance += 0.5f * objectSize; // Estimated offset from the center to the outside of the object
        //Camera.main.transform.position = boxCollider.bounds.center - distance * Camera.main.transform.forward*-20f;
    }

    void Instantiate()
    {



        for (int i = 0; i < QuadArea+1; i++)
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

        setFovForObject(Camera.main, Quad);
    }
    void SetPosition(int i)
    {
        Tiles[0].transform.position = TopLeft;

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




        if(!HalfTiles)
        {
        if(Tiles[i].transform.position.x>TopRight.x)
            Tiles[i].SetActive(false);
        if(Tiles[i].transform.position.y<-boxCollider.bounds.max.y + scale.y / 2)
         Tiles[i].SetActive(false);
        }

    }

    void setFovForObject(Camera camera, GameObject go)
    {
        Bounds bounds = getBounds(go);

        float fovY = GetFieldOfView(camera, go.transform, bounds.size.y);
        float fovX = GetFieldOfView(camera, go.transform, bounds.size.x) * ((float)camera.pixelHeight / camera.pixelWidth);

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