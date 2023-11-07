using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleClick : MonoBehaviour
{
    public SpriteRenderer pentagonSprite;
    Color newColor;

   // Start is called before the first frame update
    void Start()
    {
        //pentagonSprite = GetComponent<SpriteRenderer>();
        newColor = Color.green;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        pentagonSprite.color = newColor;
    }
}
