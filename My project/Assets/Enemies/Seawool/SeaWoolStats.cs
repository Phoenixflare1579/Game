using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SeaWoolStats : CharStats
{
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = UnityEngine.Random.Range(100, 150)+(5*Level);
        HP = MaxHP;
        Speed = UnityEngine.Random.Range(80,100) + (2 * Level);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
