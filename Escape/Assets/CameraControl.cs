using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CameraControl : MonoBehaviour
{
    public Camera camN;
    public Camera camS;
    public Camera camE;
    public Camera camW;
    public Button buttonR;
    public Button buttonL;

    // Start is called before the first frame update
    void Start()
    {
        camN.enabled = true;
        camS.enabled = false;
        camE.enabled = false;
        camW.enabled = false;

        Button btnr = buttonR.GetComponent<Button>();
        Button btnl = buttonL.GetComponent <Button>();
        btnr.onClick.AddListener(RightOnClick);
        btnl.onClick.AddListener(LeftOnClick);
        
    }

    // Update is called once per frame
    void RightOnClick()
    {
        if (camN.enabled == true)
            {
            camE.enabled = true;
            camN.enabled = false;
            }
        else if (camE.enabled == true)
            {
            camS.enabled = true;
            camE.enabled = false;
            }
        else if (camS.enabled == true)
            {
            camW.enabled = true;
            camS.enabled = false;
            }
        else if (camW.enabled == true)
            {
            camN.enabled = true;
            camW.enabled = false;
            }
        
    }

    void LeftOnClick()
    {
        if (camN.enabled == true)
            {
            camW.enabled = true;
            camN.enabled = false;
            }
        else if (camE.enabled == true)
            {
            camN.enabled = true;
            camE.enabled = false;
            }
        else if (camS.enabled == true)
            {
            camE.enabled = true;
            camS.enabled = false;
            }
        else if (camW.enabled == true)
            {
            camS.enabled = true;
            camW.enabled = false;
             }   
    }

}
