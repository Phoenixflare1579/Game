using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherWeight : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 35;
        Def = -10;
        PhysAtk = 0;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Feather Weight";
        Type = "Accessories";
    }
}
