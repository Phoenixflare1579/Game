using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStats : CharStats
{
    int EnemyHP;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("SeaWool"))
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
            target=GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CharName != "Skeleton")
        {
            if (HP < 0)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            HP = MaxHP / 2;
            CharName = "Bones";
        }
        if (target.GetComponent<KrysStats>() != null)
            EnemyHP = target.GetComponent<KrysStats>().HP;
        else if (target.GetComponent<MCStats>() != null)
            EnemyHP = target.GetComponent<MCStats>().HP;
    }

    public void Attack()
    {
        if (CharName=="SeaWool")
        {
            EnemyHP -= (int)((PhysAtk * (0.5 + (0.01 * Level))) + (UnityEngine.Random.Range(-0.02f, 0.02f) * (PhysAtk * 0.5 + (0.01 * Level))));
        }
    }

    public void Ability()
    {
        if (CharName=="SeaWool")
        {
            EnemyHP -= (int)((PhysAtk * (0.8 + (0.01 * Level))) + (UnityEngine.Random.Range(-0.02f, 0.02f) * (PhysAtk * 0.8 + (0.01 * Level))));
            HP -= (UnityEngine.Random.Range(5, 20));
        }
    }
}
