using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public InventoryManager inventoryScript;
    public ItemClass thisItem;
    public GameObject Myself;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown ()
    {
        inventoryScript.Add(thisItem); 
        Debug.Log("added?");
        Myself.SetActive(false);
    }
}
