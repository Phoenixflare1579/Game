using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightsBlade : Equipment
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 0;
        Speed = 0;
        Def = 10;
        PhysAtk = 30;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Knight's Blade";
        Type = "Sword";
    }
}
