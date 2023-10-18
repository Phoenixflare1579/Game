using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenuS : MonoBehaviour
{
    public GameObject logic;
    public void Update()
    {
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order][0] == "Krys") 
        { 
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else 
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void Attack()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<KrysStats>().Attack();
    }
}
