using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using static UnityEngine.GraphicsBuffer;

public class BoarStats : EnemyStats
{
    int Action;
    int TurnsPassed;
    // Start is called before the first frame update
    void Start()
    {
        FindLogic();
        {
            min = new int[] { 1, 70, 60, 70, 60, 60, 50, 50, 60 };
            max = new int[] { 5, 100, 80, 90, 80, 75, 65, 65, 100 };
            growth = new int[] { 5, 2, 5, 5, 3, 3, 3, 5 };
            StatRandom(min, max, growth);
            CharName = "Boar";
            position = 0;
            GetTarget();
            weakness = new string[]{ "Sword", "Spear", "Lightning", };
            SetWeakness(weakness);
            CritDmg = 25;
            Crit = 15;
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
                logic.GetComponent<BattleStartup>().Increase();
        }
    }
    private void FixedUpdate()
    {
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == gameObject.name && Dead == 0)
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
                GetTarget();
                target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.2, 0.02, target.GetComponent<CharStats>().Def, "Staff", true);
                GetTarget();
                target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.2, 0.02, target.GetComponent<CharStats>().Def, "Staff", true);
            }
        }
        else if (Action > 2)
        {
            target.GetComponent<CharStats>().Speed = (int)(0.85 * Speed);
        }
    }
}
