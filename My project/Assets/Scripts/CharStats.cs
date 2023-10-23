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
    public Dictionary<string, bool> weaknesses = new Dictionary<string, bool>();

    private void Start()
    {

    }

    public int DamageDone(double BaseDmg, double DmgStat, double BaseDmgScale, double LevelDmgAmount, double DefStat, string type, bool isNotMagic/*, GameObject Object*/)
    {

        double normDmg = BaseDmg + (Random.Range(0.98f, 1.02f) * (DmgStat * (BaseDmgScale + (LevelDmgAmount * Level)) - DefStat * 0.25));
        if (Random.Range(0, 1) <= Crit / 100 && isNotMagic)
        { 
            normDmg += normDmg * CritDmg/100;
        }
        Debug.Log(target.GetComponent<CharStats>().weaknesses.ContainsKey(type));
        if (target.GetComponent<CharStats>().weaknesses.ContainsKey(type))
        {
            normDmg += normDmg * 0.2;
            Debug.Log("Weakpoint Hit!");
        }
        return (int)normDmg;
    }
}
