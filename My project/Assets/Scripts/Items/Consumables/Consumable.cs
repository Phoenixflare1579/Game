using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable
{
    public string Name;
    public string Description;
    public int Damage;
    public int Healing;
    public int MPRestore;
    public bool AOE;

    public Consumable(string NameT, string DescriptionT, int DamageT, int HealingT, int MPRestoreT, bool AOET)
    {
        Name = NameT;
        Description = DescriptionT;
        Damage = DamageT;
        Healing = HealingT;
        MPRestore = MPRestoreT;
        AOE = AOET;
    }
}