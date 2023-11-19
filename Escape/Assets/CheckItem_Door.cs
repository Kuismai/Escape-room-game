using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckItem_Door : MonoBehaviour
{
    [SerializeField] private InventoryManager inventorySystem;
    [SerializeField] private ItemClass usedItem;
    [SerializeField] private AudioSource audioSource;
    private ItemClass activeItem;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.GetComponent<AudioSource>());
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
        audioSource.Play();
        SceneManager.LoadScene("End");

    }
}
