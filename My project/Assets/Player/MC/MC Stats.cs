using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MCStats : CharStats
{
    public Animator anim;
    public int Form = 0;
    public int Weapon = 1;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState();
        CharName = "???";
        position = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Logic") != null)
        {
            logic = GameObject.FindGameObjectWithTag("Logic");
        }
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            target = GameObject.FindGameObjectWithTag("Enemy");
        else ChangeState();
        Level = 1;
        MaxHP = 120 + (8 * Level);
        MaxMana = 50 + (5 * Level);
        Speed = 100 + (5 * Level);
        if (Speed > Max) Speed = Max;
        Def = 65 + (3 * Level);
        if (Def > Max) Def = Max;
        PhysAtk = 120 + (4 * Level);
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk = 85 + (6 * Level);
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 60 + (5 * Level);
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 60 + (5 * Level);
        if (Evasion > Max) Evasion = Max;
        Accuracy = 85 + (5 * Level);
        if (Accuracy > Max) Accuracy = Max;
        Crit = 15;
        if (Crit > CritMax) Crit = CritMax;
        CritDmg = 25;
        EXP = 0;
        EXPMax = 100 + (200 * Level);
        if (i == 0)
        {
            HP = MaxHP;
            Mana = MaxMana;
            i++;
        }
    }

    public void Attack()//Attacks will have a 2% randomization
    {
            if (Form == 1)
            {
                target.GetComponent<CharStats>().HP -= DamageDone(0, MagicAtk, 0.5, 0.01, target.GetComponent<CharStats>().Def, true);
            }
            else if (Form == 2)
            {
                target.GetComponent<CharStats>().HP -= DamageDone(0, MagicAtk, 0.7, 0.01, target.GetComponent<CharStats>().Def, true);
            }
            else
            {
                target.GetComponent<CharStats>().HP -= DamageDone(0, MagicAtk, 0.4, 0.01, target.GetComponent<CharStats>().Def, true);
            }
        logic.GetComponent<BattleStartup>().order++;
    }
    public void Defend()
    {
        logic.GetComponent<BattleStartup>().order++;
    }

    public void Flee()
    {
        int run = Random.Range(0, 4);
        if (run < 3)
            logic.GetComponent<BattleStartup>().order++;
        else
            SceneManager.LoadScene("World");
    }

    public void ChangeState()
    {
        anim.SetInteger("Weapon", 0);
    }

    public void WeaponSwap()
    {
        Weapon++;
        if (Weapon > 4) 
        {
            Weapon = 1;
        }
        anim.SetInteger("Weapon", Weapon);
    }
    public int DamageDone(double BaseDmg, double DmgStat, double DefStat, double BaseDmgScale, double LevelDmgAmount, bool isNotMagic)
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
