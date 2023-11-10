using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets up a basic code structure for game objects and handling them in other scripts.

[CreateAssetMenu(fileName = "new Item", menuName = "Item")]

public class ItemClass : ScriptableObject
{

    public string itemName;
    public Sprite itemIcon;
    public GameObject model;

    public ItemClass GetItem() { return this; }

    
}
