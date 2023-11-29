using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SeaWoolStats : EnemyStats
{
    // Start is called before the first frame update
    void Start()
    {
        FindLogic();
        {
            min = new int[] { 1, 100, 80, 70, 70, 60, 50, 50, 60 };
            max = new int[] { 5, 150, 100, 90, 85, 75, 65, 65, 100 };
            growth = new int[] { 5, 2, 5, 5, 3, 3, 3, 5 };
            StatRandom(min,max,growth);
            CharName = "SeaWool";
            position = 0;
            GetTarget();
            weakness = new string[]{ "Spear", "Knife", "Fire", "Light" };
            SetWeakness(weakness);
            CritDmg = 25;
            Crit = 15;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if (HP <= 0)
        {
            if (Dead == 0)
            {
                logic.GetComponent<BattleStartup>().xp += (int)(10 * Level / 2);
                this.tag = "Untagged";
                if (GameObject.FindGameObjectWithTag("Enemy") != null)
                    GameObject.FindGameObjectsWithTag("Enemy")[0].GetComponent<CharStats>().isTarget = true;
                Dead = 1;
            }
            GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            if (logic.GetComponent<BattleStartup>().order  < logic.GetComponent<BattleStartup>().inOrder.Length && logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == gameObject.name)
                logic.GetComponent<BattleStartup>().Increase();
        }
    }
    private void FixedUpdate()
    {
        if (logic.GetComponent<BattleStartup>().order < logic.GetComponent<BattleStartup>().inOrder.Length)
        {
            if (Dead == 0 && logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == gameObject.name)
            {
                GetTarget();
                Action = UnityEngine.Random.Range(0, 5);
                if (Action == 0)
                {
                    Attack();
                    logic.GetComponent<BattleStartup>().Increase();
                    TurnsPassed++;
                }
                else if (Action >= 1)
                {
                    Ability();
                    logic.GetComponent<BattleStartup>().Increase();
                    TurnsPassed++;
                }
            }
        }
    }
    public void Attack()
    {
        if (target.GetComponent<CharStats>() != null)
        DamageDone(BasicStaff);
    }

    public void Ability()
    {
        if (Action<=2)
        {
            if (target.GetComponent<CharStats>() != null)
            {
                DamageDone(Rampage);
            }

        }
        else if (Action>2)
        {
            Speed += (int)(1.25 * Speed);
            if (Speed > Max*1.25)
            {
                Speed = (int)(Max*1.25);
            }
        } 
    }
}
