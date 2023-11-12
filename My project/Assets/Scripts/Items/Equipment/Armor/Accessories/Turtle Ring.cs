using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleRing : Equipment
{
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 15;
        PhysAtk = 0;
        MagicAtk = 0;
        MagicDef = 15;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Turtle Ring";
        Type = "Accessories";
    }
}
