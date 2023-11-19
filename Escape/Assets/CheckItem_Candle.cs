using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem_Candle : MonoBehaviour
{
    [SerializeField] private InventoryManager inventorySystem;
    [SerializeField] private ItemClass usedItem;
    public Sprite[] imageList;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject key;
    private ItemClass activeItem;
    private float timeLeft = 2.0f;
    private int candleStage = 1;
    private bool isBurning;
    private Collider candleCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        key.gameObject.SetActive(false);
        candleCollider = GetComponent<BoxCollider>();
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
        isBurning = true;
        gameObject.GetComponent<AudioSource>().Play();
        candleStage = 2;
    }

    void Update()
    {
        if (isBurning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <0 && candleStage < 4)
            {
               
                Debug.Log(timeLeft);
                candleStage += 1;
                timeLeft = 2.0f;
                Debug.Log(candleStage);
            }

        }

        switch(candleStage)
        {
            case 2:
            spriteRenderer.sprite = imageList[1];
            break;

            case 3:
            spriteRenderer.sprite = imageList[2];
            break;

            case 4:
            spriteRenderer.sprite = imageList[3];
            key.gameObject.SetActive(true);
            candleCollider.enabled = !candleCollider.enabled;         
            isBurning = false;
            candleStage = 5;
            break;
        }


        
    }
}
