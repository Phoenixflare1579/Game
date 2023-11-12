using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithsHammer : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 55;
        MagicAtk = 15;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Smith's Hammer";
        Type = "Staff";
    }
}
