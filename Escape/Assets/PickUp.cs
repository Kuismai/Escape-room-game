using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public InventoryManager inventoryScript;
    public ItemClass thisItem;
    public GameObject Myself;
    [SerializeField] private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnMouseDown ()
    {
        inventoryScript.Add(thisItem, 1); 
        Debug.Log("added?");
        audioSource.Play(0);
        Myself.SetActive(false);
    }
}
