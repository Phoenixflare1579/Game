using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneDagger : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 30;
        MagicAtk = 30;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Arcane Dagger";
        Type = "Knife";
    }
}
