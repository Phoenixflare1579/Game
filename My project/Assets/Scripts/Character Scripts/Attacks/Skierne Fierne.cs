using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements.Experimental;

public class SkierneFierne : Attacks
{
    void Start()
    {
        Damage = 15;
        Healing = 0;
        MPCost = 10;
        HPCost = 0;
        PercentLifeSteal = 0;
        AOE = false;
        DamageType = "Fire";
        isPhysAtk = false;
        isMagicAtk = true;
    }
}
