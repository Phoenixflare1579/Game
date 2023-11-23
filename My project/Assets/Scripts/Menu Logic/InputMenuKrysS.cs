using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMenuKrysS : MonoBehaviour
{
    public GameObject logic;
    public GameObject Krys;
    public Button Button;
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
        Krys.GetComponent<KrysStats>().ChangeForm(3);
    }
    public void Mage()
    {
        Krys.GetComponent<KrysStats>().ChangeForm(2);
    }
    public void Martial()
    {
        Krys.GetComponent<KrysStats>().ChangeForm(1);
    }
    public void FireL()
    {
        Krys.GetComponent<KrysStats>().F1();
    }
    public void Drain() 
    {
        Krys.GetComponent<KrysStats>().D();
    }
    public void LightningL()
    {
        Krys.GetComponent<KrysStats>().E1();
    }
    public void IceL()
    {
        Krys.GetComponent<KrysStats>().I1();
    }
    public void BladeStorm()
    {
        Krys.GetComponent<KrysStats>().BS();
    }
    public void DemonicI()
    {
        Krys.GetComponent<KrysStats>().DI();
    }
    public void Vampirism()
    {
        Krys.GetComponent<KrysStats>().V();
    }
    public void BeyondVeil()
    {
        Krys.GetComponent<KrysStats>().BV();
    }
    public void EyesVoid()
    {
        Krys.GetComponent<KrysStats>().EV();
    }
    public void ThousandCuts()
    {
        Krys.GetComponent<KrysStats>().TC();
    }

}
