using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownofTears : Equipment
{
    void Start()
    {
        HP = -15;
        Speed = 0;
        Def = 40;
        PhysAtk = 0;
        MagicAtk = 15;
        MagicDef = 40;
        Mana = 20;
        Evasion = 0;
        Accuracy = -10;
        Crit = 0;
        CritDmg = 0;
        Name = "Crown of Tears";
        Type = "Helmet";
    }
}
