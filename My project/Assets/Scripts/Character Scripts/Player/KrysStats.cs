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
    int current=0;
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
        bonuses = new int[9];
        skilltree1 = new bool[9];
        skilltree2 = new bool[9];
        skilltree3 = new bool[9];
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Logic") != null)
            FindLogic();
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            target = generateTarget();
        else ChangeState();
        MaxHP = ((120 + (healthperlvl * Level) + bonuses[0]));
        MaxMana = 80 + (15 * Level) + bonuses[1];
        Speed = 120 + (5 * Level) + bonuses[2];
        if (Speed > Max) Speed = Max;
        Def = 55 + (3 * Level) + bonuses[3];
        if (Def > Max) Def = Max;
        PhysAtk = 100 + (4 * Level) + bonuses[4];
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk = 130 + (6 * Level) + bonuses[5];
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 95 + (5 * Level) + bonuses[6];
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 75 + (5 * Level) + bonuses[7];
        if (Evasion > Max) Evasion = Max;
        Accuracy = 85 + (5 * Level) + bonuses[8];
        if (Accuracy > Max) Accuracy = Max;
        if (Crit > CritMax) Crit = CritMax;
        EXPMax = 10 + (20 * Level * curve);
        if (Form == 3 && c == 0)
        {
            HP -= HP / 4;
            c++;
        }
        else if (Form != 3 && c == 1)
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
            this.gameObject.tag = "Untagged";
            GetComponent<Transform>().localScale = new Vector3(9, 9, 0);
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
        if (skilltree1[0] == true && skilltree1[2] == false)
        {
            bonuses[4] = 10;
        }
        else if (skilltree1[2] == true)
        {
            bonuses[4] = 25;
        }
        if (skilltree1[1] == true && skilltree1[5] == false)
        {
            bonuses[2] = 10;
        }
        else if (skilltree1[5] == true)
        {
            bonuses[2] = 35;
        }
        if (skilltree1[3] == true)
        {
            if (Form == 1 && HP < current)
            {
                DamageDone(Flick);
            }
            current = HP;
        }
        if (skilltree1[4] == true)
        {
            bonuses[1] = 20;
        }
        if (skilltree1[6] == true)
        {
            bonuses[8] = 30;
        }
        if (skilltree1[7] == true && Form == 1)
        {
            //add bladestorm and marks
        }
        if (skilltree2[0] == true && skilltree2[2] == false)
        {
            bonuses[5] = 10;
        }
        else if (skilltree2[2] == true)
        {
            bonuses[5] = 25;
        }
        if (skilltree2[1] == true && skilltree2[5] == false)
        {
            bonuses[6] = 10;
        }
        else if (skilltree2[5] == true)
        {
            bonuses[6] = 35;
        }
        if (skilltree2[3] == true && Form == 2)
        {
            // Gain Access to Insurgence
        }
        if (skilltree2[4] == true)
        {
            bonuses[1] = 20;
        }
        if (skilltree2[6] == true)
        {
            bonuses[7] = 30;
        }
        if (skilltree2[7] == true && Form == 2)
        {
            //Gain Access to Vampirism
        }
        if (skilltree3[0] == true && skilltree3[2] == false)
        {
            
        }
        else if (skilltree3[2] == true)
        {
            
        }
        if (skilltree3[1] == true && skilltree3[5] == false)
        {
            
        }
        else if (skilltree3[5] == true)
        {
            
        }
        if (skilltree3[3] == true)
        {
            
        }
        if (skilltree3[4] == true)
        {
            bonuses[1] = 20;
        }
        if (skilltree3[6] == true)
        {

        }
        if (skilltree3[7] == true)
        {

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
