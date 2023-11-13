using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SlotClass
{
    private ItemClass item;
    private int quantity;

    // Start is called before the first frame update

    public SlotClass()
    {
        item = null;
        quantity = 0;
    }

    public SlotClass (ItemClass _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }

    
    public ItemClass GetItem() { return item; }
    public int GetQuantity() { return quantity; }
    public void AddQuantity(int _quantity) { quantity += _quantity; }

}
