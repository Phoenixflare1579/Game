using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigandsAxe : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 35;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 5;
        CritDmg = 0;
        Name = "Brigand's Axe";
        Type = "Axe";
    }
}
