using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class VialofPureMind : Consumable
{
    // Start is called before the first frame update
    void Start()
    {
        Healing = 0;
        MPRestore = 75;
        Damage = 0;
        Name = "Vial of Pure Mind";
        AOE = true;
        Description = "Vial of mysterious origins that restores parties Mana for a small amount";
    }
}
