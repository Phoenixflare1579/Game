using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBerserker : Equipment
{
    void Start()
    {
        HP = 20;
        Speed = 0;
        Def = 30;
        PhysAtk = 0;
        MagicAtk = 0;
        MagicDef = 20;
        Mana = 0;
        Evasion = 0;
        Accuracy = 10;
        Crit = 15;
        CritDmg = -5;
        Name = "The Berserker";
        Type = "Chest";
    }
}
