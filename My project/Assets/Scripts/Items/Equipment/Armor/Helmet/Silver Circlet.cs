using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCirclet : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 5;
        PhysAtk = 0;
        MagicAtk = 0;
        MagicDef = 50;
        Mana = 35;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Silver Circlet";
        Type = "Helmet";
    }
}
