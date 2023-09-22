using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KrysStats : CharStats
{
    public Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 120 + (5 * Level);
        HP = MaxHP;
        MaxMana = 80 + (15 * Level);
        Mana = MaxMana;
        Speed = 120 + (5 * Level);
        if (Speed > Max) Speed = Max;
        Def = 55 + (3 * Level);
        if (Def > Max) Def = Max;
        PhysAtk = 100 + (4 * Level);
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk = 130 + (6 * Level);
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 95 + (5 * Level);
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 75 + (5 * Level);
        if (Evasion > Max) Evasion = Max;
        Accuracy = 85 + (5 * Level);
        if(Accuracy > Max) Accuracy = Max;
        Crit = 15;
        if (Crit > CritMax) Crit = CritMax;
        CritDmg = 25;
        Level = 1;
        EXP = 0;
        EXPMax = 100+(200*Level);
        CharName = "Krys";
        position = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Attack()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        if (target == null) return;
        target.GetComponent<SeaWoolStats>().HP-= ((int)(PhysAtk * 0.5 + (0.01 * Level)));
    }

    public void ChangeState()
    {
        animate.SetBool("Martial", false);
        animate.SetBool("Eldritch", true);
    }
}
