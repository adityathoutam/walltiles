using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMaker : MonoBehaviour {

    public GameObject TopWallPrefab;
    public GameObject TopWall;

    public void Awake()
    {
        TopWall = Instantiate(TopWallPrefab) as GameObject;
        TopWall.transform.parent = this.transform;
        TopWall.transform.position = new Vector3(0, -5, -3.5f);
        TopWall.transform.Rotate(90, 45, 0);
    }
}
