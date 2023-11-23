using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBearStats : EnemyStats
{
    int h = 0;
    void Start()
    {
        FindLogic();
        {
            min = new int[] { 5, 1000, 90, 160, 100, 60, 100, 40, 80 };
            max = new int[] { 5, 1000, 90, 160, 100, 60, 100, 40, 80 };
            growth = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            StatRandom(min, max, growth);
            CharName = "???";
            position = 1;
            GetTarget();
            weakness = new string[] { "Axe", "Spear", "Fire", "Light" };
            SetWeakness(weakness);
            CritDmg = 50;
            Crit = 5;
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

        if (HP <= 0 && h == 1)
        {
            if (Dead == 0)
            {
                logic.GetComponent<BattleStartup>().xp += (int)(100 * Level / 2);
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
        else if (HP < MaxHP/2 && h==0)
        {
            min = new int[] { 5, HP, 120, 90, 90, 130, 100, 40, 80 };
            max = new int[] { 5, HP, 120, 90, 90, 130, 100, 40, 80 };
            growth = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            StatRandom(min, max, growth);
            h = 1;
            GetComponent<Animator>().SetBool("H", true);
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
            DamageDone(BasicStaff);
    }

    public void Ability()
    {
        if (Action <= 2 && h==1)
        {
            DamageDone(EBeyondTheVeil);
        }
        else if (Action > 2 && h==1)
        {
            DamageDone(EEctieneZrakan);
        }
        else if (Action <= 2 && h==0)
        {
            DamageDone(ClawSwipe);
        }
        else if (Action > 2 && h == 0)
        {
            DamageDone(Crunch);
        }
    }
}
