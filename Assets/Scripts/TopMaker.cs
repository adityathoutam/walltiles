using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMaker : MonoBehaviour {

	public GameObject TopWallPrefab;
	
	private void Awake()
	{
		GameObject TopWall = Instantiate(TopWallPrefab) as GameObject;
		TopWall.transform.parent = this.transform;
		TopWall.transform.position = new Vector3(0,5,-3.5f);
		TopWall.transform.Rotate(-90,45,0);
	}
}
