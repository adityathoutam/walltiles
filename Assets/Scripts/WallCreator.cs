using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour {

	BoxCollider boxCollider;
	public float RowWidth;
	public float ColoumnWidth;
	Vector2 scale;
	
	//row_element = 	-boxCollider.bounds.min.y-scale.y/2-ColoumnWidth
	//1st row y =  	row_element-rowNumber; //0
	//2nd row y = 	row_element-rowNumber; //1


	//1st x = boxCollider.bounds.min.x+scale.x/2;

	void Start () 
	{
		boxCollider = GetComponent<BoxCollider>();
		scale = transform.GetChild(0).localScale;
	}
	
	
	void Update ()
	{
		 transform.GetChild(0).position = new Vector3(boxCollider.bounds.min.x+scale.x/2,
													-boxCollider.bounds.min.y-scale.y/2,0);

		// transform.GetChild(0).position = new Vector3(0,
		// 											 -boxCollider.bounds.min.y-scale.y/2-1.5f-ColoumnWidth,0);

			
		
		for(int i=0;i<transform.childCount-1;i++)
		{

			transform.GetChild(i+1).position = transform.GetChild(i).position;

			transform.GetChild(i+1).position = new Vector3 (transform.GetChild(i+1).position.x+scale.x+RowWidth,
													transform.GetChild(i+1).position.y,
													transform.GetChild(i+1).position.z);
													
			if(transform.GetChild(i+1).position.x>boxCollider.bounds.max.x
				&& transform.GetChild(i+1).position.y>=-boxCollider.bounds.min.y-scale.y/2-ColoumnWidth)
			{

				transform.GetChild(i+1).position = new Vector3 (boxCollider.bounds.min.x + scale.x/2,
																-boxCollider.bounds.min.y-scale.y/2-1f,0);

			}
			if(transform.GetChild(i+1).position.x>boxCollider.bounds.max.x
				&& transform.GetChild(i+1).position.y>=-boxCollider.bounds.min.y-scale.y/2-1f-ColoumnWidth)
			{

				transform.GetChild(i+1).position = new Vector3 (boxCollider.bounds.min.x + scale.x/2,
																-boxCollider.bounds.min.y-scale.y/2-2f,0);

			}
				
		}	

		
		

	
	}
}

		





