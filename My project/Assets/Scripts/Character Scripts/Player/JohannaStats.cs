using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JohannaStats : PlayerStats
{
    public Sprite Die;
    int r = 0;
    int m = 0;
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
        skilltree1 = new bool[9];
        skilltree2 = new bool[9];
        skilltree3 = new bool[9];
        for (int i = 0; i < 9; i++)
        {
            skilltree1[i] = false;
            skilltree2[i] = false;
            skilltree3[i] = false;
        }
        MaxHP = 105;
        MaxMana = 80;
        Speed = 130;
        if (Speed > Max) Speed = Max;
        Def = 70;
        if (Def > Max) Def = Max;
        PhysAtk = 80;
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk = 100;
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 90;
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 60;
        if (Evasion > Max) Evasion = Max;
        Accuracy = 85;
        if (Accuracy > Max) Accuracy = Max;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Logic") != null)
            FindLogic();
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            target = generateTarget();
        else ChangeState();
        if (Crit > CritMax) Crit = CritMax;
        EXPMax = 10 + (20 * Level * curve);
        if (LvlUP == 0)
        {
            MaxHP += healthperlvl;
            MaxMana += 12;
            Speed += 6;
            Def += 6;
            PhysAtk += 5;
            MagicAtk += 6;
            MagicDef += 5;
            Evasion += 3;
            Accuracy += 5;
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
            this.gameObject.tag = "Untagged";
            GetComponent<SpriteRenderer>().sprite = Die;
            anim.enabled = false;
            if (logic != null)
                if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name)
                    logic.GetComponent<BattleStartup>().Increase();
            if (SceneManager.GetActiveScene().name != "Combat")
            {
                HP = 1;
                r = 0;
                m = 0;
            }
            if (skilltree2[3] == true && Form == 2)
            {
                if (HP == 0 && r==0)
                {
                    HP = 1;
                    r = 1;
                }
            }
            if (skilltree3[3] == true)
            {
                if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
                {
                    bonuses[2] = 35;
                    bonuses[4] = 50;
                    bonuses[5] = 50;
                }
            }
            if (skilltree3[7] == true)
            {
                if (logic != null)
                {
                    int l = 0;
                    if (GameObject.FindGameObjectsWithTag("Enemy") != null && m == 0)
                    {
                        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
                        {
                            l += GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<CharStats>().Level;
                        }
                        if ((l + 3) / GameObject.FindGameObjectsWithTag("Enemy").Length < Level - 10)
                        {
                            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
                            {
                                DamageDone(Execution);
                            }
                        }
                    }
                    m = 1;
                }
            }
        }
        else if (HP > 0)
        {
            anim.enabled = true;
            this.gameObject.tag = "Player";
        }
    }
    public void Attack()//Attacks will have a 2% randomization
    {
        if (Form == 1)
        {
            DamageDone(BasicSpear);
            if (skilltree1[3] == true && target.GetComponent<CharStats>().Speed < Speed)
            {
                DamageDone(BasicSpear);
            }
            if (skilltree1[7] == true)
            {
                DamageDone(GentleLight);
            }
        }
        else if (Form == 2)
        {
            DamageDone(BasicSpear);
        }
        else
        {
            DamageDone(BasicSpear);
            DamageDone(Double);
        }
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void L1()
    {
        DamageDone(HolyLight);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void GS()
    {
        DamageDone(GodSpeed);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void H1()
    {
        DamageDone(Heal);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void S()
    {
        DamageDone(Sweep);
        logic.GetComponent<BattleStartup>().Increase();
        if (skilltree1[3] == true)
        {
            if (Form == 1 && target.GetComponent<CharStats>().Speed < Speed)
            {
                DamageDone(BasicSpear);
            }
        }
    }
    public void PS()
    {
        DamageDone(PiercingStrike);
        if (skilltree1[3] == true)
        {
            if (Form == 1 && target.GetComponent<CharStats>().Speed < Speed)
            {
                DamageDone(BasicSpear);
            }
        }
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void SOS()
    {
        DamageDone(SacramentofSacrifice);
        logic.GetComponent<BattleStartup>().Increase();
    }
}
