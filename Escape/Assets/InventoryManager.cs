using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotList;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;

    public void Start()
    {
        // Get all inventory slots
        slots = new GameObject[slotList.transform.childCount];
        for (int i = 0; i < slotList.transform.childCount; i++)
        {
            slots[i] = slotList.transform.GetChild(i).gameObject;
        }

        RefreshUI();
        
        //Remove(itemToRemove);
        Add(itemToAdd);
    }

    public void RefreshUI()
    {

        for( int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }

    public void Add(ItemClass item)
    {
        SlotClass slot = Contains(item);
        if (slot != null)
        {
            slot.AddQuantity(1);
        }
        else
        {
            items.Add(new SlotClass (item, 1));
        }
        RefreshUI();
    }

    public void Remove(ItemClass item)
    {
        SlotClass slotR = new SlotClass();
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
            {
                slotR = slot;
                break;
            }
        }
       items.Remove(slotR);
        RefreshUI();
    }

    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
            {
                return slot;
            }
        }

        return null;
    }
}
