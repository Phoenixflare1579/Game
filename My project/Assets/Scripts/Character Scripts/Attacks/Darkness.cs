using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : Attacks
{
    // Start is called before the first frame update
    void Start()
    {
        Damage = 15;
        Healing = 0;
        MPCost=0;
        HPCost=25;
        PercentLifeSteal=0;
        AOE=false;
        DamageType="Dark";
        isPhysAtk=false;
        isMagicAtk=true;
    }
}
