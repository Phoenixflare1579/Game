using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenuMCS : MonoBehaviour
{
    public GameObject logic;
    public GameObject MC;

    private void Start()
    {
        MC = GameObject.Find("MC");
    }
    public void Update()
    {
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == "MC")
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
        MC.GetComponent<MCStats>().Attack();
    }
    public void Defend()
    {
        MC.GetComponent<MCStats>().Defend();
    }
    public void Flee()
    {
        MC.GetComponent<MCStats>().Flee();
    }
    public void WeaponSwap()
    {
        MC.GetComponent<MCStats>().WeaponSwap();
    }
    public void BladesUnbound()
    {
        MC.GetComponent<PlayerStats>().ChangeForm(3);
    }
    public void Dog()
    {
        MC.GetComponent<PlayerStats>().ChangeForm(2);
    }
    public void Martial()
    {
        MC.GetComponent<PlayerStats>().ChangeForm(1);
    }
    public void Sweep()
    {
        MC.GetComponent<MCStats>().S();
    }
    public void Experiment()
    {
        MC.GetComponent<MCStats>().EX();
    }
    public void PiercingStrike()
    {
        MC.GetComponent<MCStats>().PS();
    }
    public void CrossStrike()
    {
        MC.GetComponent<MCStats>().CS();
    }
    public void Cleave()
    {
        MC.GetComponent<MCStats>().C();
    }
    public void Backstab()
    {
        MC.GetComponent<MCStats>().BS();
    }
    public void Bladewhirl()
    {
        MC.GetComponent<MCStats>().BW();
    }
    public void GuillotineStrike()
    {
        MC.GetComponent<MCStats>().GS();
    }
}
