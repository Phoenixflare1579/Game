using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorningStar : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 35;
        MagicAtk = 5;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Morning Star";
        Type = "Staff";
    }
}
