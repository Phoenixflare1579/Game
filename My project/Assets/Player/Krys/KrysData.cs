using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class KrysData
{
    public int level;
    public int exp;
    public bool[] skills;
    public int skillpoints;
    public int health;
    public int mana;
    public KrysData(KrysStats stats)
    {
        level = stats.Level;
        exp = stats.EXP;
        skillpoints = stats.skillpoints;
        health = stats.HP;
        mana = stats.Mana;
    }
}
