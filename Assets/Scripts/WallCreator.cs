using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour {

	BoxCollider boxCollider;
	public float RowWidth;
	public float ColoumnWidth;
	Vector2 scale;

    GameObject[] TileArray;
    GameObject[] TileArray2;



    //1st x = boxCollider.bounds.min.x+scale.x/2;

    void Start () 
	{
		boxCollider = GetComponent<BoxCollider>();
		scale = transform.GetChild(0).localScale;
        TileArray = new GameObject[transform.childCount];
        TileArray2 = new GameObject[transform.childCount];
    }
	
	
	void Update ()
	{
		
	     transform.GetChild(0).position = new Vector3(boxCollider.bounds.min.x+scale.x/2,
													-boxCollider.bounds.min.x-scale.y/2-ColoumnWidth,0);

      
       
        //for(int i=0; i<99;i++)
        //{
        //    SetPosition(i);
        //}
        for (int i = 10; i < 100; i = i + 10)
        {
            Init(i);

        }
        for (int i = 0; i < 9; i++)
        {


            SetPosition(i);

        }
        for (int i = 10; i < 19; i++)
        {

            SetPosition(i);
        }
        for (int i = 20; i < 29; i++)
        {

            SetPosition(i);
        }
        for (int i = 30; i < 39; i++)
        {

            SetPosition(i);
        }
        for (int i = 40; i < 49; i++)
        {

            SetPosition(i);
        }
        for (int i = 50; i < 59; i++)
        {

            SetPosition(i);
        }
        for (int i = 60; i < 69; i++)
        {

            SetPosition(i);
        }
        for (int i = 70; i < 79; i++)
        {

            SetPosition(i);
        }
        for (int i = 80; i < 89; i++)
        {

            SetPosition(i);
        }
        for (int i = 90; i < 99; i++)
        {

            SetPosition(i);
        }





    }
    void SetPosition(int i)
    {
        


            transform.GetChild(i + 1).position = transform.GetChild(i).position;

            transform.GetChild(i + 1).position = new Vector3(transform.GetChild(i + 1).position.x + scale.x + RowWidth,
                                                    transform.GetChild(i + 1).position.y,
                                                    transform.GetChild(i + 1).position.z);
        
    }
    void Init(int i)
    {
        transform.GetChild(i).position = new Vector3(transform.GetChild(i - 10).position.x,
                                                 transform.GetChild(i - 10).position.y - 1f - ColoumnWidth, 0);

    }





}


		





