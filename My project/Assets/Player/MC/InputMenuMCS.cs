using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenuMCS : MonoBehaviour
{
    public GameObject logic;
    public GameObject MC;

    private void Start()
    {
        Debug.Log("InputMenuMCs");
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
}
