using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventoryExp : MonoBehaviour
{

    public RectTransform rectTransform;
    private bool expanded;
    public Button buttonI;
    float yAxis, xAxis, yAxis2;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();    
        expanded = true;
        Button btI = buttonI.GetComponent<Button>();
        btI.onClick.AddListener(OnClickInv);
        xAxis = 00;
        yAxis = -100;
        yAxis2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickInv()
    {
        if (expanded == true)
        {
            Debug.Log("true!");
            rectTransform.anchoredPosition = new Vector2(xAxis, yAxis);
            expanded = false;
        }
        else
        {
            Debug.Log("false!");
            expanded = true;
            rectTransform.anchoredPosition = new Vector2(xAxis, yAxis2);
        }
    }

}
