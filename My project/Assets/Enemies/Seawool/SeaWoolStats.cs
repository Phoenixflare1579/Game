using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SeaWoolStats : CharStats
{
    int Action;
    int TurnsPassed;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic");
        {
            Level = UnityEngine.Random.Range(1, 5);
            MaxHP = UnityEngine.Random.Range(100, 150) + (5 * Level);
            HP = MaxHP;
            Speed = UnityEngine.Random.Range(80, 100) + (2 * Level);
            Def = UnityEngine.Random.Range(70, 90) + (5 * Level);
            PhysAtk = UnityEngine.Random.Range(70, 85) + (5 * Level);
            MagicAtk = UnityEngine.Random.Range(60, 75) + (3 * Level);
            MagicDef = UnityEngine.Random.Range(50, 65) + (3 * Level);
            Evasion = UnityEngine.Random.Range(50, 65) + (3 * Level); ;
            Accuracy = UnityEngine.Random.Range(60, 100) + (5 * Level); ;
            Crit = 15;
            CritDmg = 25;
            CharName = "SeaWool";
            target=GameObject.FindGameObjectsWithTag("Player")[UnityEngine.Random.Range(0,GameObject.FindGameObjectsWithTag("Player").Length-1)];
            weaknesses.Add("Spear", true);
            weaknesses.Add("Knife", true);
            weaknesses.Add("Fire", true);
            weaknesses.Add("Light", true);
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
            logic.GetComponent<BattleStartup>().xp += (int)(10 * Level / 2);
            for (int i = 0, j=0; i < logic.GetComponent<BattleStartup>().inOrder.Length; i++)
            {
                if (logic.GetComponent<BattleStartup>().inOrder[i][0] == gameObject.name)
                {
                    j = 1;
                }
                if (j==1 && logic.GetComponent<BattleStartup>().inOrder[i][0] != gameObject.name)
                {
                    logic.GetComponent<BattleStartup>().inOrder[i - 1][0] = logic.GetComponent<BattleStartup>().inOrder[i - 1][0];
                    logic.GetComponent<BattleStartup>().inOrder[i - 1][1] = logic.GetComponent<BattleStartup>().inOrder[i - 1][1];
                }
            }
            logic.GetComponent<BattleStartup>().inOrder = logic.GetComponent<BattleStartup>().inOrder.Take(logic.GetComponent<BattleStartup>().inOrder.Length - 1).ToArray();
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order][0] == gameObject.name)
        {
            target = GameObject.FindGameObjectsWithTag("Player")[UnityEngine.Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length)];
            Action = UnityEngine.Random.Range(0, 5);
            if (Action == 0)
            {
                Attack();
                logic.GetComponent<BattleStartup>().order++;
                TurnsPassed++;
            }
            else if (Action >= 1)
            {
                Ability();
                logic.GetComponent<BattleStartup>().order++;
                TurnsPassed++;
            }
        }
    }
    public void Attack()
    {
        if (target.GetComponent<CharStats>() != null)
        target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.3, 0.01, target.GetComponent<CharStats>().Def, "Sword", true);
    }

    public void Ability()
    {
        if (Action<=2)
        {
            if (target.GetComponent<CharStats>() != null)
            {
                target.GetComponent<CharStats>().HP -= DamageDone(5, PhysAtk, 0.4, 0.02, target.GetComponent<CharStats>().Def, "Staff", true);
                HP -= HP/4;
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
