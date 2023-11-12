using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskoftheCursed : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = -20;
        PhysAtk = 25;
        MagicAtk = 0;
        MagicDef = -5;
        Mana = 0;
        Evasion = 0;
        Accuracy = -5;
        Crit = 5;
        CritDmg = 10;
        Name = "Mask of the Cursed";
        Type = "Helmet";
    }
}
