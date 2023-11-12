using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class WolfStats : EnemyStats
{
    int Action;
    int TurnsPassed;
    // Start is called before the first frame update
    void Start()
    {
        FindLogic();
        {
            min = new int[] { 1, 70, 90, 60, 80, 60, 50, 50, 60 };
            max = new int[] { 5, 90, 100, 70, 90, 75, 65, 65, 100 };
            growth = new int[] { 5, 2, 4, 6, 3, 3, 3, 5 };
            StatRandom(min, max, growth);
            CharName = "Wolf";
            position = 0;
            GetTarget();
            weakness = new string[]{"Sword","Axe", "Fire"};
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
                logic.GetComponent<BattleStartup>().xp += (int)(7 * Level / 2);
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
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == gameObject.name)
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
            target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.4, 0.01, target.GetComponent<CharStats>().Def, "Knife", true);
    }

    public void Ability()
    {
        if (Action <= 2)
        {
            if (target.GetComponent<CharStats>() != null)
            {
                target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.4, 0.02, target.GetComponent<CharStats>().Def- target.GetComponent<CharStats>().Def/4, "Knife", true);
            }

        }
        else if (Action > 2)
        {

            if (target.GetComponent<CharStats>() != null)
            {
                int D = DamageDone(0, PhysAtk, 0.4, 0.02, target.GetComponent<CharStats>().Def, "Knife", true);
                target.GetComponent<CharStats>().HP -= D;
                HP += D / 4;
                if (HP > MaxHP)
                {
                    HP = MaxHP;
                }
            }
        }
    }
}