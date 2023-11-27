using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    public int HP;
    public int Speed;
    public int Def;
    public int PhysAtk;
    public int MagicAtk;
    public int MagicDef;
    public int Mana;
    public int Evasion;
    public int Accuracy;
    public int Crit;
    public int CritDmg;
    public string Type;
    public string Name;

    public Equipment(int HPT, int SpeedT, int DefT, int PhysAtkT, int MagicAtkT, int MagicDefT, int ManaT, int EvasionT, int AccuracyT, int CritT, int CritDmgT, string TypeT, string NameT)
    {
        HP = HPT;
        Speed = SpeedT;
        Def = DefT;
        PhysAtk = PhysAtkT;
        MagicAtk = MagicAtkT;
        MagicDef = MagicDefT;
        Mana = ManaT;
        Evasion = EvasionT;
        Accuracy = AccuracyT;
        Crit = CritT;
        CritDmg = CritT;
        Type = TypeT;
        Name = NameT;
    }
}
