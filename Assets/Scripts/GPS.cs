using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public CanvasMenu canvasMenu;
    public Camera gpsCamera;
    private void Awake()
    {
        gpsCamera = GetComponent<Camera>();
        if (gpsCamera.rect == new Rect(1, 1, 1, 1))
            canvasMenu.gpsC = 0;
        else if (gpsCamera.rect == new Rect(0.69f, 0.34f, 0.3f, 0.3f))
            canvasMenu.gpsC = 1;
        else if (gpsCamera.rect == new Rect(0, 0, 1, 1))
            canvasMenu.gpsC = 2;
    }
    public void GPSCameraOn()
    {

        gpsCamera.rect = new Rect(0.69f, 0.34f, 0.3f, 0.31f);
        
    }
    public void GPSCameraOff()
    {
        gpsCamera.rect = new Rect(1, 1, 1, 1);
            
        
    }
    public void GPSCameraScreen()
    {
        gpsCamera.rect = new Rect(0, 0, 1, 1);

       
    }
    

}