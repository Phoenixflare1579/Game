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
    public int Level;
    public int EXP;
    public int EXPMax;
    public string CharName;
    public int position;
    public GameObject logic;
    public string[] weakness;

    public int DamageDone(double BaseDmg, double DmgStat, double BaseDmgScale, double LevelDmgAmount, double DefStat, bool isNotMagic)
    {
        double normDmg = BaseDmg + (Random.Range(-0.98f, 1.02f) * (DmgStat * (BaseDmgScale + (LevelDmgAmount * Level)) - DefStat * 0.25));
        if (Random.Range(0, 1) <= Crit / 100 && isNotMagic)
        {
            return (int)(normDmg + normDmg * CritDmg);
        }
        else
        {
            return (int)normDmg;
        }
    }
}
