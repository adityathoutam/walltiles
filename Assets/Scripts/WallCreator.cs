using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour {

	BoxCollider boxCollider;
    Vector2 scale;
	public float RowWidth;
	public float ColoumnWidth;
    public GameObject TilePrefab;
	

    void Start () 
	{
         Instantiate();
		boxCollider = GetComponent<BoxCollider>();
       
        
    }
    void Instantiate()
    {
        for(int i=0; i<100;i++)
        {
           Instantiate(TilePrefab,Vector3.zero,Quaternion.identity,transform);
        }
    }
	
	
	void Update ()
	{ 
		 scale = transform.GetChild(0).localScale;
             transform.GetChild(0).position = new Vector3(boxCollider.bounds.min.x+scale.x/2,
													-boxCollider.bounds.min.x-scale.y/2,0);

        
      
       
        for(int i=0; i<99;i++)
        {
           SetPosition(i);

         
        }

    }
    void SetPosition(int i)
    {
        for (int j = 10; j < 100; j = j + 10)
         {
            transform.GetChild(j).position = new Vector3(transform.GetChild(j - 10).position.x,
                                                 transform.GetChild(j - 10).position.y -scale.y - ColoumnWidth, 0);
         }
      
       
            transform.GetChild(i + 1).position = transform.GetChild(i).position;

            transform.GetChild(i + 1).position = new Vector3(transform.GetChild(i + 1).position.x + scale.x + RowWidth,
                                                    transform.GetChild(i + 1).position.y,
                                                    transform.GetChild(i + 1).position.z);
         
    }

}


		





