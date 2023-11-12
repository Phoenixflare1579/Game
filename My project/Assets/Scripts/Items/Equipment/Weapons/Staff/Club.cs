using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 7;
        MagicAtk = 3;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Club";
        Type = "Staff";
    }
}
