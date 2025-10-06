using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCamera : MonoBehaviour
{
    public Camera sideCamera;
    public CanvasMenu canvasMenu;
    // Start is called before the first frame update
    void Start()
    {
        sideCamera = GetComponent<Camera>();

        if (sideCamera.rect == new Rect(0.69f, 0.02f, 0.3f, 0.3f))
            canvasMenu.sideC = 1;
        else if (sideCamera.rect == new Rect(1, 0, 1, 1))
            canvasMenu.sideC = 0;
        else if (sideCamera.rect == new Rect(0, 0, 1, 1))
            canvasMenu.sideC = 2;
    }
    public void SideCameraOn()
    {
        sideCamera.rect = new Rect(0.69f, 0.02f, 0.3f, 0.3f);
        
    }

    public void SideCameraOff()
    {
        sideCamera.rect = new Rect(1, 0, 1, 1);
       
    }
    public void SideCameraScreen()
    {
        sideCamera.rect = new Rect(0, 0, 1, 1);
        
    }
}
