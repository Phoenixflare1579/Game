using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohannaStats : PlayerStats
{
    public Sprite Die;
    // Start is called before the first frame update
    void Start()
    {
        CharName = "Johanna";
        position = 2;
        target = GameObject.FindGameObjectWithTag("Enemy");
        DontDestroyOnLoad(this.gameObject);
        Level = 1;
        EXP = 0;
        WType = "Spear";
        healthperlvl = 8;
        anim.SetInteger("Phase", 1);
        Form = 1;
        anim.SetInteger("Form", Form);
        CritDmg = 25;
        Crit = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Logic") != null)
            FindLogic();
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            target = generateTarget();
        else ChangeState();
        MaxHP = (105 + (healthperlvl * Level));
        MaxMana = 80 + (12 * Level);
        Speed = 130 + (5 * Level);
        if (Speed > Max) Speed = Max;
        Def = 70 + (6 * Level);
        if (Def > Max) Def = Max;
        PhysAtk = 80 + (5 * Level);
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk = 100 + (6 * Level);
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 90 + (5 * Level);
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 60 + (3 * Level);
        if (Evasion > Max) Evasion = Max;
        Accuracy = 85 + (5 * Level);
        if (Accuracy > Max) Accuracy = Max;
        if (Crit > CritMax) Crit = CritMax;
        EXPMax = 10 + (20 * Level * curve);
        if (LvlUP == 0)
        {
            HP = MaxHP;
            Mana = MaxMana;
            LvlUP++;
        }
        if (EXP >= EXPMax)
        {
            Level++;
            if (Level == 10 || Level == 20 || Level == 30 || Level == 40 || Level == 50 || Level == 60 || Level == 70 || Level == 80 || Level == 90)
            {
                skillperlvl++;
                healthperlvl += 3;
                curve = Level * curve;
            }
            EXP -= EXPMax;
            skillpoints += skillperlvl;
            LvlUP--;
        }
        if (HP <= 0)
        {
            HP = 0;
            GetComponent<SpriteRenderer>().sprite = Die;
            anim.enabled = false;
            if (logic != null)
                if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name)
                    logic.GetComponent<BattleStartup>().Increase();
        }
        else if (HP > 0)
        {
            anim.enabled = true;
        }
    }
}
