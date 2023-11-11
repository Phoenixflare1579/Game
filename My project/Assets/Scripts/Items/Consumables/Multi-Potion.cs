using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPotion : Consumable
{
    void Start()
    {
        Healing = 35;
        MPRestore = 0;
        Damage = 0;
        Name = "Multi-Potion";
        AOE = true;
        Description = "Large potion that Heals party for a small amount";
    }
}
