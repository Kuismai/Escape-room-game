using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CloseUp : MonoBehaviour
{
    public Camera prevCamera;
    public Camera newCamera;
    public Button leftButton;
    public Button rightButton;
    public Button backButton;
    public int layers;
    public CameraControl controller;


    // Start is called before the first frame update
    void Start()
    {
        newCamera.enabled = false;
        
    }

    public void OnMouseDown()
    {
        closeUp();
    }
    
    
    public void closeUp()
    {
        prevCamera.enabled = false;
        newCamera.enabled = true;
        
        if (layers == 0)
        {
        rightButton.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
        }

        controller.setCurrent(this);
             
    }

    public void returnCamera()
    {
        newCamera.enabled = false;
        prevCamera.enabled = true;

        if (layers == 0)
        {
        rightButton.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        }

    }
}
