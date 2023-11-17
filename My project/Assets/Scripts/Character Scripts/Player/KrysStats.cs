using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class KrysStats : PlayerStats
{
    int c = 0;
    public Sprite Die;
    // Start is called before the first frame update
    void Start()
    {
        CharName = "Krys";
        position = 1;
        target = GameObject.FindGameObjectWithTag("Enemy");
        DontDestroyOnLoad(this.gameObject);
        Level = 1;
        EXP = 0;
        WType = "Knife";
        healthperlvl = 5;
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
        MaxHP = (120 + ( healthperlvl * Level));
        MaxMana = 80 + (15 * Level);
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
        if (Accuracy > Max) Accuracy = Max;
        if (Crit > CritMax) Crit = CritMax;
        EXPMax = 10 + (20 * Level * curve);
        if (Form == 3 && c==0)
        {
            HP -= HP / 4;
            c++;
        }
        else if (Form != 3 && c==1)
        {
            c = 0;
        }
        if (LvlUP == 0)
        {
            HP = MaxHP;
            Mana = MaxMana;
            LvlUP++;
        }
        if (EXP >= EXPMax)
        {
            Level++;
            if (Level == 10 || Level==20 || Level == 30 || Level == 40 || Level == 50 || Level == 60 || Level == 70 || Level == 80 || Level == 90)
            {
                skillperlvl++;
                healthperlvl += 3;
                curve = Level * curve;
            }
            EXP -= EXPMax;
            skillpoints += skillperlvl;
            LvlUP--;
        }
        if (HP<=0)
        {
            HP = 0;
            GetComponent<SpriteRenderer>().sprite = Die;
            this.gameObject.tag = "Untagged";
            GetComponent<Transform>().localScale = new Vector3(9,9,0);
            anim.enabled = false;
            if (logic != null)
            if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name)
                logic.GetComponent<BattleStartup>().Increase();
            if (SceneManager.GetActiveScene().name != "Combat")
            {
                HP = 1;
            }
        }
        else if (HP > 0)
        {
            GetComponent<Transform>().localScale = new Vector3(26, 26, 0);
            anim.enabled = true;
            this.gameObject.tag = "Player";
        }
    }
    public void Attack()//Attacks will have a 2% randomization
    {
            if (Form == 1)
            {
                DamageDone(BasicDagger);
            }
            else if (Form == 2)
            {
            DamageDone(BasicDagger);
            }
            else
            {
            DamageDone(BasicDagger);
            }
        logic.GetComponent<BattleStartup>().Increase();
    }

    public void FireBall()
    {
        DamageDone(BasicSword);
        logic.GetComponent<BattleStartup>().Increase();
    }

    public void Drain()
    {
        DamageDone(BasicSword);
        logic.GetComponent<BattleStartup>().Increase();
    }
}
