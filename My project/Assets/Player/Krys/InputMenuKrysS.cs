using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenuKrysS : MonoBehaviour
{
    public GameObject logic;
    public GameObject Krys;
    private void Start()
    {
        Krys = GameObject.Find("Krys");
    }
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
        Krys.GetComponent<KrysStats>().Attack();
    }
    public void Defend() 
    {
        Krys.GetComponent<KrysStats>().Defend();
    }
    public void Flee()
    {
        Krys.GetComponent<KrysStats>().Flee();
    }
}
