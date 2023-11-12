using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartShapedNecklace : Equipment
{
    void Start()
    {
        HP = 50;
        Speed = 0;
        Def = 0;
        PhysAtk = 0;
        MagicAtk = 0;
        MagicDef = 0;
        Mana = 0;
        Evasion = 0;
        Accuracy = 0;
        Crit = 0;
        CritDmg = 0;
        Name = "Heart Shaped Necklace";
        Type = "Accessories";
    }
}
