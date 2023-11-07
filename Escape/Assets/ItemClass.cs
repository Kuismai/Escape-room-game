using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Item")]
public class ItemClass : ScriptableObject
{

    public string itemName;
    public Sprite itemIcon;
    public GameObject model;

    public ItemClass GetItem() { return this; }

    
}
