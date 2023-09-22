using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartup : MonoBehaviour
    
{
    public GameObject[] playerP;
    public GameObject[] enemyP;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerP.Length; i++)
        {
            Instantiate(playerP[i]);
        }

        for (int i = 0; i < enemyP.Length; i++)
        {
            Instantiate(enemyP[i]);
        }
    }

    
}
