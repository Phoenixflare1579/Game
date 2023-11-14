using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolneIcante : Attacks
{
    void Start()
    {
        Damage = 15;
        Healing = 0;
        MPCost = 10;
        HPCost = 0;
        PercentLifeSteal = 0;
        AOE = false;
        DamageType = "Ice";
        isPhysAtk = false;
        isMagicAtk = true;
    }
}
