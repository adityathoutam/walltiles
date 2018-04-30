﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaker : MonoBehaviour {

	public GameObject LeftWall;
	public GameObject RightWall;
	public  GameObject TilePrefab;
	public float RowWidth,ColoumnWidth;

 float QuadWidth, QuadHeight, QuadArea;
  BoxCollider boxCollider;
    Vector2 scale;
	Vector2 TopLeft, TopRight;
 List<GameObject> Tiles = new List<GameObject>();

	void Awake()
    {

           // LeftWall.transform.parent = transform;

            scale = TilePrefab.transform.localScale;
            boxCollider = LeftWall.GetComponent<BoxCollider>();
            QuadWidth = LeftWall.transform.localScale.x;
            QuadHeight = LeftWall.transform.localScale.y;
            QuadArea = QuadHeight / scale.y * QuadWidth / scale.x;



            Instantiate();
        
    }

    void Instantiate()
    {



        for (int i = 0; i < QuadArea+1; ++i)
        {
            GameObject go = Instantiate(TilePrefab, Vector3.zero, Quaternion.identity);
            go.transform.parent = LeftWall.transform.parent;

            Tiles.Add(go);
        }


        TopLeft = new Vector2(boxCollider.bounds.min.x + scale.x / 2,
                 -boxCollider.bounds.min.y - scale.y / 2);
        TopRight = new Vector2(boxCollider.bounds.max.x - scale.x / 2,
                  boxCollider.bounds.max.y - scale.y / 2);

        Tiles[0].transform.position = TopLeft;

    }
	void Start()
    {


     for (int i = 0; i < QuadArea; i++)
        {
            SetPosition(i);
            Tiles[i].transform.parent = LeftWall.transform;
        }
        
       
    }
private IEnumerator f()
 {
    while (true)
    {
       
      yield return null; //after having done things, exit this loop and wait null frames before reentering. So the next frame 'things' will happen again.  
    }
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

}