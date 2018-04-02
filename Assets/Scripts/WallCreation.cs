using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator2 : MonoBehaviour {

	BoxCollider boxCollider;
    Vector2 scale;
	public float RowWidth;
	public float ColoumnWidth;
    public GameObject TilePrefab;

	List<GameObject> Tiles = new List<GameObject>();
	

    void Start () 
	{
         Instantiate();
		boxCollider = GetComponent<BoxCollider>();
       
        
    }
    void Instantiate()
    {
        for(int i=0; i<100;i++)
        {
           GameObject go =Instantiate(TilePrefab,Vector3.zero,Quaternion.identity);
		   Tiles.Add(go);
        }
    }
	
	
	void Update ()
	{ 
		
		scale = Tiles[0].transform.localScale;

             Tiles[0].transform.position = new Vector3(boxCollider.bounds.min.x+scale.x/2,
													-boxCollider.bounds.min.x-scale.y/2,0);

        
      
       
        for(int i=0; i<99;i++)
        {
            SetLocalScale(i);
           SetPosition(i);

         
        }

    }

    void SetLocalScale(int i )
    {
        Tiles[i+1].transform.localScale = Tiles[0].transform.localScale;

    }

    void SetPosition(int i)
    {


        for (int j = 10; j < 100; j = j + 10)
         {
             Tiles[j].transform.position = new Vector3( Tiles[j-10].transform.position.x,
                                                 Tiles[j-10].transform.position.y -scale.y - ColoumnWidth, 0);
         }
      
       
            Tiles[i+1].transform.position = Tiles[i].transform.position;

            Tiles[i+1].transform.position = new Vector3(Tiles[i+1].transform.position.x + scale.x + RowWidth,
                                                    Tiles[i+1].transform.position.y,
                                                    Tiles[i+1].transform.position.z);
         
    }

}


		





