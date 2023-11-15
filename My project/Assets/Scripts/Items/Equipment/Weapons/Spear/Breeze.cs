using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeze : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 50;
        Def = 0;
        PhysAtk = 40;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "The Breeze";
        Type = "Spear";
    }//Increases healing by 15%

}
