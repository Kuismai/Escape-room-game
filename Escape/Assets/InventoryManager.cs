using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotList;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    public List<ItemClass> items = new List<ItemClass>();

    private GameObject[] slots;

    public void Start()
    {
        // Get all inventory slots
        slots = new GameObject[slotList.transform.childCount];
        
        //Remove(itemToRemove);
        //Add(itemToAdd);
    }

    public void Add(ItemClass item)
    {
        items.Add(item);
    }

    public void Remove(ItemClass item)
    {
        items.Remove(item);
    }
}
