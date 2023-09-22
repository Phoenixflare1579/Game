using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public GameObject target;
    public int HP;
    public int MaxHP;
    public int Speed;
    public const int Max = 999;
    public int Def;
    public int PhysAtk;
    public int MagicAtk;
    public int MagicDef;
    public int MaxMana;
    public int Mana;
    public int Evasion;
    public int Accuracy;
    public int Crit;
    public int CritDmg;
    public const int CritMax = 100;
    public int Level = 1;
    public int EXP = 0;
    public int EXPMax = 100;
    public string CharName = "name";
    public int position;
}
