using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ThrowingKnife : Consumable
{
    // Start is called before the first frame update
    void Start()
    {
        Healing = 0;
        MPRestore = 0;
        Damage = 100;
        Name = "Throwing Knife";
        AOE = false;
        Description = "Knife that can be thrown for minor damage to a target.";
    }
}
