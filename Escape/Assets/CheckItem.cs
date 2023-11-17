using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : MonoBehaviour
{
    [SerializeField] private InventoryManager inventorySystem;
    [SerializeField] private ItemClass usedItem;
    private ItemClass activeItem;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        activeItem = inventorySystem.movingSlot.GetItem();
        
        if (activeItem != null)
        {
            if (activeItem == usedItem)
                {
                    success();
                    inventorySystem.movingSlot.Clear();
                    inventorySystem.isMovingItem = false;
                }
            else
            {
                Debug.Log("not the one");
            }
        }
        
    }

    void success()
    {
        Debug.Log("success!");
    }
}
