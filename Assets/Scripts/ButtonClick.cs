using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

    public GameObject DimensionsCanvas;
    public GameObject TileCanvas;
    public GameObject View3DCanvas;
    public GameObject PriceCanvas;

    public GameObject CanvasCamera;

   
   public void Awake()
   {
       DimensionsCanvasBtn();
   }
    public void DimensionsCanvasBtn()
    {
        DimensionsCanvas.SetActive(true);
        TileCanvas.SetActive(false);
        PriceCanvas.SetActive(false);
        View3DCanvas.SetActive(false);
        
    }
    
    public void TileCnvasBtn()
    {
        DimensionsCanvas.SetActive(false);
        TileCanvas.SetActive(true);
        PriceCanvas.SetActive(false);
        View3DCanvas.SetActive(false);
         CanvasCamera.SetActive(true);
     //    this.GetComponent<UserInfo>().DestoryYhreeDWall();
        this.GetComponent<UserInfo>().ThreeDBtnClick =0;

     
    }

    public void View3DCanvasBtn()
    {
        DimensionsCanvas.SetActive(false);
        TileCanvas.SetActive(false);
        PriceCanvas.SetActive(false);
        View3DCanvas.SetActive(true);
    }

    public void PriceCanvasBtn()
    {
        DimensionsCanvas.SetActive(false);
        TileCanvas.SetActive(false);
        PriceCanvas.SetActive(true);
        View3DCanvas.SetActive(false);
        CanvasCamera.SetActive(true);

        this.GetComponent<UserInfo>().DestoryYhreeDWall();
        this.GetComponent<UserInfo>().ThreeDBtnClick =0;
         
    }

    public void ThreeDBtn()
    {
        DimensionsCanvas.SetActive(false);
        TileCanvas.SetActive(false);
        PriceCanvas.SetActive(false);
        View3DCanvas.SetActive(true);
      
    }
    public void ThreeDBtnBACK()
    {
        DimensionsCanvas.SetActive(true);
        TileCanvas.SetActive(false);
        PriceCanvas.SetActive(false);
        View3DCanvas.SetActive(false);
        
    }


}
