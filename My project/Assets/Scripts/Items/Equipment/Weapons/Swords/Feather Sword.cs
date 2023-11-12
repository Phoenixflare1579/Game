using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherSword : Equipment
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 0;
        Speed = 25;
        Def = 0;
        PhysAtk = 45;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 10;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Feather Sword";
        Type = "Sword";
    }
}
