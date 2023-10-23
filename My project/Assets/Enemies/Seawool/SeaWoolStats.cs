using System;
using System.Collections;
using System.Collections.Generic;
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
            MaxHP = UnityEngine.Random.Range(100, 150) + (5 * Level);
            HP = MaxHP;
            Speed = UnityEngine.Random.Range(80, 100) + (2 * Level);
            Def = UnityEngine.Random.Range(70, 90) + (5 * Level);
            PhysAtk = UnityEngine.Random.Range(80, 100) + (5 * Level);
            MagicAtk = UnityEngine.Random.Range(60, 75) + (3 * Level);
            MagicDef = UnityEngine.Random.Range(50, 65) + (3 * Level);
            Evasion = UnityEngine.Random.Range(50, 65) + (3 * Level); ;
            Accuracy = UnityEngine.Random.Range(60, 100) + (5 * Level); ;
            Crit = 15;
            CritDmg = 25;
            Level = UnityEngine.Random.Range(1, 5); ;
            CharName = "SeaWool";
            target=GameObject.FindGameObjectsWithTag("Player")[UnityEngine.Random.Range(0,GameObject.FindGameObjectsWithTag("Player").Length-1)];
            weakness = new string[4] {"Spear","Knife","Fire","Ice"};
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order][0] == gameObject.name)
        {
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
        target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.5, 0.01, target.GetComponent<CharStats>().Def, true);
    }

    public void Ability()
    {
        if (Action<=2)
        {
            if (target.GetComponent<CharStats>() != null)
            {
                target.GetComponent<CharStats>().HP -= DamageDone(10, PhysAtk, 0.6, 0.02, target.GetComponent<CharStats>().Def, true);
                HP -= 10;
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
