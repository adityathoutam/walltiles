using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleWallCreator : MonoBehaviour {

	public GameObject Wall;
	public GameObject Tile;

	public GameObject WallPrefab;
	
	public  GameObject TilePrefab;
    
	 float RowWidth,ColoumnWidth;

    float QuadWidth, QuadHeight, QuadArea;

    BoxCollider boxCollider;

     Vector2 scale;

    public GameObject GameManager;

    public GameObject CanvasCamera;
   
	Vector2 TopLeft;
	 //Vector2 TopRight;
    public int ThreeDBtnClick;	

	 public List<GameObject> Tiles = new List<GameObject>();



    private void Update()
    {

        

        float xa =  GameManager.GetComponent<UserInfo>().Tile_H_Num;
            float ya = GameManager.GetComponent<UserInfo>().Tile_W_Num;

            scale.x=xa;
            scale.y =ya; 
        RowWidth = GameManager.GetComponent<UserInfo>().Grout_H_Num;
        ColoumnWidth = GameManager.GetComponent<UserInfo>().Grout_W_Num;


        if(Wall!=null)
        {
            float x = 10; //GameManager.GetComponent<UserInfo>().Wall_A_W_Num;
            float y =10; //GameManager.GetComponent<UserInfo>().Wall_A_W_Num;

            Wall.transform.localScale= new Vector3(x,y,1); 
        }


        if(Wall!=null)
        {
             Material GroutMaterial = GameManager.GetComponent<UserInfo>().GroutMaterial;
           
            Wall.GetComponent<Renderer>().material = GroutMaterial;
        }
        for (int i=0;i<Tiles.Count;i++)
        {
            Material TileMaterial = GameManager.GetComponent<UserInfo>().TileMaterial;
            //Tile.GetComponent<Renderer>().material= GroutMaterial;
            if(Tiles[i]!=null)
            {
            Tiles[i].GetComponent<Renderer>().material = TileMaterial;

            
            }


        }



    }

public void DestoryOneDWall()
{
    if(Wall!=null)
    {
    Destroy(Wall);
    }

}




    public void Create()
    {
        if(ThreeDBtnClick==0)
        {
            if(Wall==null)
            {
            Camera.main.fieldOfView=60f;
            if(GameManager.GetComponent<UserInfo>().CompletedRoom!=null)
                Destroy(GameManager.GetComponent<UserInfo>().CompletedRoom);
             CanvasCamera.SetActive(false);
		     StartCoroutine(StartCounting());
                
               ThreeDBtnClick++;
               return;
        }
        }

        if(ThreeDBtnClick==1)
        {
             CanvasCamera.SetActive(true);
                Destroy(Wall);
                Tiles.Clear();
                
                 
                  ThreeDBtnClick=0;
                  return;
        }
    }


     IEnumerator StartCounting()
    {
          Awake2();
       
        yield return new WaitForSeconds(0.1f);

            StartFunction();  
            Destroy(Tiles[Tiles.Count-1]);

        yield return new WaitForSeconds(0.1f);
    }
    
    void StartFunction()
    {
	    for (int i = 0; i < QuadArea; i++)
        {
            SetPosition(i);
            Tiles[i].transform.parent = Wall.transform;
			
        }
    }
	void Awake2()
    {
       
        Wall = Instantiate(WallPrefab) as GameObject;
		Tile = Instantiate(TilePrefab) as GameObject;
         Wall.transform.localScale = new Vector3(10,10,1f);
        Tile.transform.localScale = new Vector3(GameManager.GetComponent<UserInfo>().Tile_W_Num,
                                                    GameManager.GetComponent<UserInfo>().Tile_H_Num,0.01f);

        Wall.transform.parent = this.transform;
        boxCollider = Wall.GetComponent<BoxCollider>();
        QuadWidth = Wall.transform.localScale.x;
        QuadHeight = Wall.transform.localScale.y;
        QuadArea = QuadHeight / scale.y * QuadWidth / scale.x;
        Instantiate();
        
    }

	void Instantiate()
    {
        
      //  TilePrefab.transform.localScale = scale;
      //  TilePrefab.transform.localScale = new Vector3(TilePrefab.transform.localScale.x,TilePrefab.transform.localScale.y,0.1f);

        Tiles.Add(Tile);
       TilePrefab.transform.localScale = new Vector3(GameManager.GetComponent<UserInfo>().Tile_H_Num,
                                                    GameManager.GetComponent<UserInfo>().Tile_W_Num,0.01f);
       
       
        for (int i = 1; i < QuadArea+1; ++i)
        {
            GameObject go = Instantiate(TilePrefab, Vector3.zero, Quaternion.identity);
            go.transform.parent = Wall.transform.parent;
            
            Tiles.Add(go);
        }


        TopLeft = new Vector2(boxCollider.bounds.min.x + scale.x / 2,
                 -boxCollider.bounds.min.y - scale.y / 2);
        // TopRight = new Vector2(boxCollider.bounds.max.x - scale.x / 2,
        //           boxCollider.bounds.max.y - scale.y / 2);

        
        Tiles[0].transform.position = TopLeft;
        

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

          //Tiles[i + 1].transform.localScale = Tiles[i].transform.localScale;
          Tiles[i + 1].transform.position = Tiles[i].transform.position;

        Tiles[i + 1].transform.position = new Vector3(Tiles[i + 1].transform.position.x + scale.x + RowWidth,
                                                Tiles[i + 1].transform.position.y,
                                                Tiles[i + 1].transform.position.z);


		


    }
  

}
