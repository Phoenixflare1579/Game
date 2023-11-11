using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class TearsofDivine : Consumable
{
    // Start is called before the first frame update
    void Start()
    {
        Healing = 0;
        MPRestore = 50;
        Damage = 0;
        Name = "Tears of Time";
        AOE = false;
        Description = "Tears of a diety lost to Time. Restores targets Mana for a small amount";
    }
}
