using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingBoxCollider : MonoBehaviour {

	public GameObject Tile;
	public GameObject Wall;
	BoxCollider boxCollider;
	Vector2 scale;
	GameObject gameObj;
	Vector2 TopRowLeft;
	Vector2 TopRowRight;
	List<GameObject> Tiles = new List<GameObject>();

	public float RowWidth;
    public float ColoumnWidth;

	void Awake()
	{
		boxCollider = Wall.GetComponent<BoxCollider>();
		scale = new Vector2(Tile.transform.localScale.x,Tile.transform.localScale.y);
	//	gameObj=Instantiate(Tile);
	Instantiate();
	}

	
	//Top Left = boxCollider.bounds.min.x+scale.x/2
	//             -boxCollider.bounds.min.y-scale.y/2

	//Top Right = boxCollider.bounds.max.x-scale.x/2;
	//              boxCollider.bounds.max.y-scale.y/2

	void Start () {

			TopRowLeft = new Vector2(boxCollider.bounds.min.x+scale.x/2,
	            					 -boxCollider.bounds.min.y-scale.y/2);
			TopRowRight = new Vector2(boxCollider.bounds.max.x-scale.x/2,
				                     boxCollider.bounds.max.y-scale.y/2);

		
	}
	void Update()
	{
		for(int i=0; i<30;i++)
        {
		if(i==0)
          SetPosition(i,0);
		  else
		  SetPosition2(i);
        }
		
	}

	void Instantiate()
    {
        for(int i=0; i<30;i++)
        {
           GameObject go =Instantiate(Tile,Vector3.zero,Quaternion.identity);
		   Tiles.Add(go);
        }
    }

	 void SetPosition(int i,int row)
    {
		if(row==0)
		Tiles[i].transform.position = new Vector2(TopRowLeft.x,TopRowLeft.y);
		else
		Tiles[i].transform.position = new Vector2(TopRowLeft.x,TopRowLeft.y-row-ColoumnWidth);

        
	}
	void SetPosition2(int i )
      {     
		if(Tiles[i].transform.position.x>TopRowRight.x&&Tiles[i])
		 { if(transform.position.y==TopRowRight.y-ColoumnWidth)
			SetPosition(i,1);
			else if(Tiles[i].transform.position.y==TopRowRight.y-1-ColoumnWidth)
			SetPosition(i,2);
			else if(Tiles[i].transform.position.y==TopRowRight.y-2-ColoumnWidth)
			SetPosition(i,3);
			else if(Tiles[i].transform.position.y==TopRowRight.y-3-ColoumnWidth)
			SetPosition(i,4);
		}
		  
		else
		{

		   Tiles[i].transform.localScale = Tiles[i-1].transform.localScale;
		   Tiles[i].transform.position = Tiles[i-1].transform.position; 
          

            Tiles[i].transform.position = new Vector3(Tiles[i].transform.position.x + scale.x+RowWidth,
                                                    Tiles[i].transform.position.y,
                                                    Tiles[i].transform.position.z);    
		
		}
	  }

	 

	

}
