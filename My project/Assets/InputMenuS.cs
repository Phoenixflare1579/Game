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
            this.gameObject.SetActive(true);
        }
        else 
        { 
            this.gameObject.SetActive(false); 
        }
    }
    public void Attack()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<KrysStats>().Attack();
    }
}
