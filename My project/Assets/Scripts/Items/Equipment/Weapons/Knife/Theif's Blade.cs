using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheifsBlade : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 15;
        Def = 0;
        PhysAtk = 40;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 5;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Theif's Blade";
        Type = "Knife";
    }
}
