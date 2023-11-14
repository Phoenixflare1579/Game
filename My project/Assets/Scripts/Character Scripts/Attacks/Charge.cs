using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Attacks
{
    void Start()
    {
        Damage = 20;
        Healing = 0;
        MPCost = 5;
        HPCost = 15;
        PercentLifeSteal = 0;
        AOE = false;
        DamageType = "Staff";
        isPhysAtk = true;
        isMagicAtk = false;
    }
}
