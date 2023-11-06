using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using static UnityEngine.GraphicsBuffer;

public class BoarStats : CharStats
{
    int Action;
    int TurnsPassed;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic");
        {
            Level = UnityEngine.Random.Range(1, 5);
            MaxHP = UnityEngine.Random.Range(70, 100) + (5 * Level);
            HP = MaxHP;
            Speed = UnityEngine.Random.Range(60, 80) + (2 * Level);
            Def = UnityEngine.Random.Range(70, 90) + (5 * Level);
            PhysAtk = UnityEngine.Random.Range(60, 80) + (5 * Level);
            MagicAtk = UnityEngine.Random.Range(60, 75) + (3 * Level);
            MagicDef = UnityEngine.Random.Range(50, 65) + (3 * Level);
            Evasion = UnityEngine.Random.Range(50, 65) + (3 * Level); ;
            Accuracy = UnityEngine.Random.Range(60, 100) + (5 * Level); ;
            Crit = 15;
            CritDmg = 25;
            CharName = "Boar";
            position = 0;
            target = GameObject.FindGameObjectsWithTag("Player")[UnityEngine.Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length - 1)];
            weaknesses.Add("Sword", true);
            weaknesses.Add("Spear", true);
            weaknesses.Add("Lightning", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget==true)
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
            if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == gameObject.name)
                logic.GetComponent<BattleStartup>().order++;
        }
    }
    private void FixedUpdate()
    {
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == gameObject.name && Dead == 0)
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
            target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.3, 0.01, target.GetComponent<CharStats>().Def, "Staff", true);
    }

    public void Ability()
    {
        if (Action <= 2)
        {
            if (target.GetComponent<CharStats>() != null)
            {
                target = GameObject.FindGameObjectsWithTag("Player")[UnityEngine.Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length - 1)];
                target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.2, 0.02, target.GetComponent<CharStats>().Def, "Staff", true);
                target = GameObject.FindGameObjectsWithTag("Player")[UnityEngine.Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length - 1)];
                target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.2, 0.02, target.GetComponent<CharStats>().Def, "Staff", true);
            }
        }
        else if (Action > 2)
        {
            target.GetComponent<CharStats>().Speed = (int)(0.85 * Speed);
        }
    }
}
