using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySystem", menuName = "CustomScriptableObject/InventorySystem")]
public class InventorySystem : ScriptableObject
{
    public ItemClass itemToAdd;
    public ItemClass itemToRemove;

    public List<ItemClass> items = new List<ItemClass>();

    public void Start()
    {
        Remove(itemToRemove);
        Add(itemToAdd);
    }

    public void Add(ItemClass item)
    {
        items.Add(item);
        Debug.Log("tried to add!");
    }

    public void Remove(ItemClass item)
    {
        items.Remove(item);
        Debug.Log("tried to remove!");
    
    }
}
