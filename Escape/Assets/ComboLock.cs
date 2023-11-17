using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboLock : MonoBehaviour
{
    public LockCheck lockCheck;
    public ChangeValue digit1;
    public ChangeValue digit2;
    public ChangeValue digit3;
    public ChangeValue digit4;
    public GameObject thisLock;
    public GameObject openCabinet;
    private int[] offer = {0, 0, 0, 0};
    private int[] solution = {1, 0, 2, 5};

    // Start is called before the first frame update
    void Start()
    {
        openCabinet.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        offer[0] = digit1.getValue();
        offer[1] = digit2.getValue();
        offer[2] = digit3.getValue();
        offer[3] = digit4.getValue();

        if (lockCheck.CheckMatch(offer, solution))
        {
            onSolve();
        }
    }

    void onSolve()
    {
        openCabinet.gameObject.SetActive(true);
        thisLock.gameObject.SetActive(false);
    }
    
}

