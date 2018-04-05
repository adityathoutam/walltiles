using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallCreation : MonoBehaviour {

	BoxCollider boxCollider;
    Vector2 scale;
	public float RowWidth;
	public float ColoumnWidth;
    public GameObject TilePrefab;

    public Slider Row;
    public Slider Coloumn;
    public Slider TileHeight;

    Vector2 TopLeft,TopRight;
    int QuadWidth,QuadHeight,QuadArea;

  
	List<GameObject> Tiles = new List<GameObject>();
	

    void Awake () 
	{
       boxCollider = GetComponent<BoxCollider>();
       QuadWidth =(int) transform.localScale.x;
       QuadHeight = (int) transform.localScale.y;
       QuadArea = QuadHeight*QuadWidth;

        Instantiate();
      Invoke("SetPosition",0.0001f);
        
    }
    void SetPosition()
    {
          for(int i=0; i<QuadArea-1;i++)
          {
           // SetLocalScale(i);
           SetPosition(i);
       
          }

    }
    void Instantiate()
    {
        TopLeft = new Vector2(boxCollider.bounds.min.x+scale.x/2,
	             -boxCollider.bounds.min.y-scale.y/2);

	    TopRight = new Vector2( boxCollider.bounds.max.x-scale.x/2,
	              boxCollider.bounds.max.y-scale.y/2);

        for(int i=0; i<QuadArea;i++)
        {
           GameObject go =Instantiate(TilePrefab,Vector3.zero,Quaternion.identity);
		   Tiles.Add(go);
        }
    }

    

    
	
	void Update ()
	{
        RowWidth = Row.value;
        ColoumnWidth = Coloumn.value;

		scale = Tiles[0].transform.localScale;

             Tiles[0].transform.position = new Vector3(boxCollider.bounds.min.x+scale.x/2,
													-boxCollider.bounds.min.y-scale.y/2,0);

          for(int i=0; i<QuadArea-1;i++)
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
       

        for (int j = QuadWidth; j < QuadArea; j = j + QuadWidth)
        {
             Tiles[j].transform.position = new Vector3( Tiles[j-QuadWidth].transform.position.x,
                                                 Tiles[j-QuadWidth].transform.position.y -scale.y - ColoumnWidth, 0);
        
        }
        
            Tiles[i+1].transform.position = Tiles[i].transform.position;
          

            Tiles[i+1].transform.position = new Vector3(Tiles[i+1].transform.position.x + scale.x + RowWidth,
                                                    Tiles[i+1].transform.position.y,
                                                    Tiles[i+1].transform.position.z);    
    }
}