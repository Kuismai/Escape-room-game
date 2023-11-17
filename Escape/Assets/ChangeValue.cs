using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeValue : MonoBehaviour
{
    public int value = 0;
    public Sprite[] imageList;
    public SpriteRenderer spriteRenderer;
    public int max;

    void OnMouseDown()
    {
        if (value < max)
        {
            value += 1;
        }
        else
        {
            value = 0;
        }
        spriteRenderer.sprite = imageList[value];
    }

    public int getValue()
    {
        return value;
    }
}
