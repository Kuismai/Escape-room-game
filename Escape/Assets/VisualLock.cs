using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLock : MonoBehaviour
{
    public LockCheck lockCheck;
    public ChangeValue digit1;
    public ChangeValue digit2;
    public ChangeValue digit3;
    public ChangeValue digit4;
    public GameObject thisLock;
    public GameObject openDrawer;
    private int[] offer = {0, 0, 0, 0};
    private int[] solution = {4, 2, 3, 1};

    // Start is called before the first frame update
    void Start()
    {
        openDrawer.gameObject.SetActive(false);
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
        Debug.Log("You did it!");
        openDrawer.gameObject.SetActive(true);
        thisLock.gameObject.SetActive(false);

    }
}
