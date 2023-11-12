using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtStaff : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 15;
        MagicAtk = 70;
        MagicDef = 0;
        Mana = 0;
        Evasion = -5;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Court Staff";
        Type = "Staff";
    }
}
