using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenKnife : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 15;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Kitchen Knife";
        Type = "Knife";
    }
}
