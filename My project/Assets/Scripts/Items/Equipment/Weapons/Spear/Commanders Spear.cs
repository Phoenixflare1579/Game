using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandersSpear : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 45;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Commander's Spear";
        Type = "Spear";
    } //Gives random chance for attack boost for allies.
}
