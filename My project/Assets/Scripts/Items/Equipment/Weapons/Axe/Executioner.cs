using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 0;
        PhysAtk = 55;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = -15;
        Crit = 10;
        CritDmg = 15;
        Name = "The Executioner";
        Type = "Axe";
    }
}
