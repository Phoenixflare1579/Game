using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Bomb : Consumable
{
    // Start is called before the first frame update
    void Start()
    {
        Healing = 0;
        MPRestore = 0;
        Damage = 70;
        Name = "Bomb";
        AOE = true;
        Description = "Small bomb that can be thrown for minor damage to the full party";
    }
}
