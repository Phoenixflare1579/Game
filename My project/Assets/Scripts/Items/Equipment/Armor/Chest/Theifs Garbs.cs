using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheifsGarbs : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 25;
        Def = 30;
        PhysAtk = 0;
        MagicAtk = 0;
        MagicDef = 25;
        Mana = 0;
        Evasion = 10;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Theif's Garbs";
        Type = "Chest";
    }
}
