using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicAttack : Attacks
{
    private void Start()
    {
        BaseDmg = 0;
        BaseDmgScale = 0;
        LevelDmgAmount = 0;
        Healing = 0;
        MPCost = 0;
        HPCost = 0;
        PercentLifeSteal = 0;
        AOE = false;
        DamageType = string.Empty;
        isPhysAtk = true;
        isMagicAtk = false;
    }
}
