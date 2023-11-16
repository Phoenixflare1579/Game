using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBearStats : EnemyStats
{
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

        if (HP <= 0)
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
    }
}
