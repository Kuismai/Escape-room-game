using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCheck : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool CheckMatch(int[] offer, int[] solution)
    {
        string offer1 ="";
        string solution1 ="";
        for (var i = 0; i < offer.Length; i++)
        {
            offer1 = offer1 + offer[i].ToString();
        }

        for (var i = 0; i < solution.Length; i++)
        {
            solution1 = solution1 + solution[i].ToString();
        }
        
        if (solution1 == offer1)
        {
            Debug.Log("Correct!");
            return true;
        }
        else
        {
            Debug.Log("Incorrect!");
            return false;
        }
        
    }
}
