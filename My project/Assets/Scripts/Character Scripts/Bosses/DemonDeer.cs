using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDeer : EnemyStats
{
    // Start is called before the first frame update
    void Start()
    {
        FindLogic();
        {
            min = new int[] { 7, 700, 100, 130, 90, 90, 80, 50, 70 };
            max = new int[] { 7, 700, 100, 130, 90, 90, 80, 50, 70 };
            growth = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            StatRandom(min, max, growth);
            CharName = "The Demonic Deer";
            position = 0;
            GetTarget();
            weakness = new string[] { "Axe", "Light" };
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
                logic.GetComponent<BattleStartup>().xp += (int)(5 * Level / 2);
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
            DamageDone(BasicStaff);
    }

    public void Ability()
    {
        if (Action == 1)
        {
            if (target.GetComponent<CharStats>() != null)
            {
                DamageDone(HornSlam);
            }

        }
        else if (Action >= 2 && Action < 4)
        {
            DamageDone(ESkeirnaFiernie);
        }
        else if (Action >= 4)
        {
            DamageDone(ESolneIcante);
        }
    }
}
