using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Consumable
{
    void Start()
    {
        Healing = 50;
        MPRestore = 0;
        Damage = 0;
        Name = "Potion";
        AOE = false;
        Description = "Basic potion. Heals target for a small amount";
    }
}
