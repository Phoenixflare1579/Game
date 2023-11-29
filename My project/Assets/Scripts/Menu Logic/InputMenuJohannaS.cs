using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenuJohannaS : MonoBehaviour
{
    public GameObject logic;
    public GameObject Johanna;

    private void Start()
    {
        Johanna = GameObject.Find("Johanna");
    }
    public void Update()
    {
        if (logic.GetComponent<BattleStartup>().order < logic.GetComponent<BattleStartup>().inOrder.Length)
            if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == "Johanna")
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
        Johanna.GetComponent<JohannaStats>().Attack();
    }
    public void Defend()
    {
        Johanna.GetComponent<JohannaStats>().Defend();
    }
    public void Flee()
    {
        Johanna.GetComponent<JohannaStats>().Flee();
    }
    public void FlyingSpear()
    {
        Johanna.GetComponent<PlayerStats>().ChangeForm(3);
    }
    public void HolyCommander()
    {
        Johanna.GetComponent<PlayerStats>().ChangeForm(2);
    }
    public void Warrior()
    {
        Johanna.GetComponent<PlayerStats>().ChangeForm(1);
    }
    public void Sweep()
    {
        Johanna.GetComponent<JohannaStats>().S();
    }
    public void PiercingStrike()
    {
        Johanna.GetComponent<JohannaStats>().PS();
    }
    public void Heal()
    {
        Johanna.GetComponent<JohannaStats>().H1();
    }
    public void Godspeed()
    {
        Johanna.GetComponent<JohannaStats>().GS();
    }
    public void HolyLight()
    {
        Johanna.GetComponent<JohannaStats>().L1();
    }
    public void SacramentofSacrifice()
    {
        Johanna.GetComponent<JohannaStats>().SOS();
    }
}
