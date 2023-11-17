using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public double BaseDmg;
    public double BaseDmgScale;
    public double LevelDmgAmount;
    public int Healing;
    public int MPCost;
    public int HPCost;
    public double PercentLifeSteal;
    public bool AOE;
    public string DamageType;
    public bool isPhysAtk;
    public bool isMagicAtk;
    public Attacks(double BaseDmgC, double BaseDmgScaleC, double LevelDmgAmountC, int HealingC, int MPCostC, int HPCostC, double PercentLifeStealC, bool AOEC, string DamageTypeC, bool isPhysAtkC, bool isMagicAtkC)
    {
        BaseDmg = BaseDmgC;
        BaseDmgScale = BaseDmgScaleC;
        LevelDmgAmount = LevelDmgAmountC;
        Healing = HealingC;
        MPCost = MPCostC;
        HPCost = HPCostC;
        PercentLifeSteal = PercentLifeStealC;
        AOE = AOEC;
        DamageType = DamageTypeC;
        isPhysAtk = isPhysAtkC;
        isMagicAtk = isMagicAtkC;
    }
}
