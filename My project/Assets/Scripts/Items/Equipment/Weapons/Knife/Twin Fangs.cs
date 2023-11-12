using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinFangs : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 5;
        Def = 0;
        PhysAtk = 25;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 5;
        CritDmg = 0;
        Name = "Twin Fangs";
        Type = "Knife";
    } //should have passive to hit twice on basic attacks
}
