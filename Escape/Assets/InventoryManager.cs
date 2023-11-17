using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    [SerializeField] private GameObject itemCursor;

    [SerializeField] private GameObject slotList;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;


    private SlotClass[] items;

    private GameObject[] slots;

    public SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;

    public bool isMovingItem = false;
    

    public void Start()
    {
        // Get all inventory slots
        slots = new GameObject[slotList.transform.childCount];
        items = new SlotClass[slots.Length];
        
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }

        for (int i = 0; i < slotList.transform.childCount; i++)
        {
            slots[i] = slotList.transform.GetChild(i).gameObject;
        }

        RefreshUI();
        
    //    Remove(itemToRemove);
        Add(itemToAdd, 1);
    }

    private void Update()
    {
        itemCursor.SetActive(isMovingItem);
        itemCursor.transform.position = Input.mousePosition;
        
        if (isMovingItem)
        {
            itemCursor.GetComponent<Image>().sprite = movingSlot.GetItem().itemIcon;
        }
        

        if (Input.GetMouseButtonDown(0)) //mouse has been clicked
        {
            if (isMovingItem)
            {
                EndItemMove();
            }
            else
            {
                BeginItemMove();
            }
        }
    }

    #region Inventory Utils

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

    
    public bool Add(ItemClass item, int quantity)
    {
        SlotClass slot = Contains(item);
        if (slot != null)
        {
            slot.AddQuantity(1);
        }
        else
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null) //means slot is empty
                {
                    items[i] = new SlotClass(item, 1);
                    break;
                }
            }

            /*if (items.Count < slots.Length)
            {
                items.Add(new SlotClass (item, 1));
            }
            else
            {
                return false;
            }*/
        }
        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {
        SlotClass slotR = Contains(item);
        if (slotR != null)
        {
            if (slotR.GetQuantity() > 1)
            slotR.SubQuantity(1);
        
            else
            {
                int slotToRemoveInd = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveInd = i;
                        break;
                    }
                }
       
      
                items[slotToRemoveInd].Clear();
            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

    public SlotClass Contains(ItemClass item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == item)
            {
                return items[i];
            }
        }

        return null;
    }

    #endregion

    #region Using Stuff


    #endregion

    #region Moving Stuff

    private bool BeginItemMove()
    {
        originalSlot = GetClosestSlot();

        if (originalSlot == null || originalSlot.GetItem() == null)
        {
            return false; //no slot or no item in slot
        }

        movingSlot = new SlotClass(originalSlot);
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove()
    {
        originalSlot = GetClosestSlot();
        //activeObject = GetClosestInteractable();

        if (originalSlot != null)
        {
            if (originalSlot.GetItem() != null)
            {
                if (originalSlot.GetItem() == movingSlot.GetItem()) //same item
                {
                    originalSlot.AddQuantity(movingSlot.GetQuantity());
                    isMovingItem = false;
                }
                else
                {
                    tempSlot = new SlotClass(originalSlot); // save what's in the slot
                    originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity());
                    movingSlot.AddItem(tempSlot.GetItem(), tempSlot.GetQuantity());
                    
                    RefreshUI();
                    return true;
                }
            }
            else // place item in empty slot
            {
                originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity());
                movingSlot.Clear();
                
                isMovingItem = false;
                RefreshUI();
                return true;
            }
        }

        
        RefreshUI();

        return true;
    }

    private SlotClass GetClosestSlot()
    {
        Debug.Log(Input.mousePosition);

        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 52)
            {
                return items[i];
            }
        }

        return null;
    }

    /*private GameObject GetClosestInteractable()
    {
        for (int i = 0; i < interactables.Length; i++)        
        {
            if (Vector2.Distance(interactables[i].transform.position, Input.mousePosition) <= 352)
            {
                Debug.Log("Found you!");
                return interactables[i];
            }
        }

        return null;
    }*/

    #endregion

}
