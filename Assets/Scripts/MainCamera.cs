using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Camera mainCamera;
   
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    public void MainCameraAdjustOn()
    {
        mainCamera.rect = new Rect(0, 0, 1, 1);
        
    }
    public void MainCameraAdjustSmaller()
    {
        mainCamera.rect = new Rect(0, 0, 0.7f, 1);
        
    }
    public void MainCameraOff()
    {
        mainCamera.rect = new Rect(1, 1, 1, 1);
    }
}
