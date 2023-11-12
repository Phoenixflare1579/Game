using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingofFire : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 30;
        PhysAtk = 0;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Ring of Fire";
        Type = "Accessories";
    } //Each turn Def and PhysAtk swap
}
