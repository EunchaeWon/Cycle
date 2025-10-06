using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMenu : MonoBehaviour
{
    public Button[] ButtonList;
    int buttonList;
    

    public MainCamera mainCamera;
    public GPS gpsScript;
    public SideCamera sideCameraScript;
    
    public int gpsC;
    public int sideC;


    // Update is called once per frame
    public void ButtonMove(int b)
    {
        if(buttonList == 0 && b == -1 )
        {
            b = 1;
        }
        else if(buttonList ==1 && b==1)
        {
            b = -1;
        }
        buttonList = buttonList +b;
        
        ButtonList[buttonList].image.color = new Color32(100, 255, 255, 255);
        if (buttonList == 0)
        {
            ButtonList[1].image.color = new Color32(255, 255, 255, 255);
        }
        else if (buttonList == 1)
        {
            ButtonList[0].image.color = new Color32(255, 255, 255, 255);
        }
        
        

    }
    public void SpaceBar()
    {
        if(buttonList==0)
        {

            if (gpsC==2)
            {
                gpsScript.GPSCameraOff();
                gpsC = 0;
                mainCamera.MainCameraAdjustOn();
            }

            else if(gpsC==0)
            {
                gpsScript.GPSCameraOn();
                gpsC = 1;
            }   
            else if(gpsC == 1)
            {
                gpsScript.GPSCameraScreen();
                gpsC = 2;
                sideCameraScript.SideCameraOff();
                sideC = 0;
                mainCamera.MainCameraOff();
            }
            //ButtonList[buttonList].onClick
        }
        else if(buttonList ==1)
        {
            if (sideC == 2)
            {
                sideCameraScript.SideCameraOff();
                sideC = 0;
                mainCamera.MainCameraAdjustOn();
            }
                
            else if (sideC == 0)
            {
                sideCameraScript.SideCameraOn();
                sideC = 1;
            }
            
            else if (sideC == 1)
            {
                sideCameraScript.SideCameraScreen();
                sideC = 2;
                gpsScript.GPSCameraOff();
                gpsC = 0;
                mainCamera.MainCameraOff();
            }
               
        }
        /*
        if (gpsC == 1 && sideC == 1)
            mainCamera.MainCameraAdjustSmaller();
        else if (gpsC == 0 || sideC == 0)
            mainCamera.MainCameraAdjustBigger();
        else if (gpsC == 2 || sideC == 2)
            mainCamera.MainCameraOff();
        */

    }

    
}
