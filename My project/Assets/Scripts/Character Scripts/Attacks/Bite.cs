using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements.Experimental;

public class Bite : Attacks
{
    void Start()
    {
        Damage = 5;
        Healing = 0;
        MPCost = 10;
        HPCost = 0;
        PercentLifeSteal = 25;
        AOE = false;
        DamageType = "Knife";
        isPhysAtk = true;
        isMagicAtk = false;
    }
}
