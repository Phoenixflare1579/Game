using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMenuKrysS : MonoBehaviour
{
    public GameObject logic;
    public GameObject Krys;
    int i=0;
    private void Start()
    {
        Debug.Log("InputMenuKrys");
        Krys = GameObject.Find("Krys");
    }
    public void Update()
    {
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == "Krys") 
        { 
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if (i == 0)
            {
                this.gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Button>().interactable = true;
                i++;
            }
        }
        else 
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            i = 0;
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
    public void Eldritch()
    {
        Krys.GetComponent<KrysStats>().Eldritch();
    }
    public void Mage()
    {
        Krys.GetComponent<KrysStats>().Mage();
    }
    public void Martial()
    {
        Krys.GetComponent<KrysStats>().Martial();
    }
    public void FireBall()
    {
        Krys.GetComponent<KrysStats>().FireBall();
    }
    public void Drain() 
    {
        Krys.GetComponent<KrysStats>().Drain();
    }
}
