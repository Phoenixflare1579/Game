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
    int l = 0;
    int t = 0;
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
        skilltree1 = new bool[9];
        skilltree2 = new bool[9];
        skilltree3 = new bool[9];
        for (int i = 0; i < 9; i++)
        {
            skilltree1[i] = false;
            skilltree2[i] = false;
            skilltree3[i] = false;
        }
        MaxHP = 120;
        MaxMana = 80;
        Speed = 120;
        if (Speed > Max) Speed = Max;
        Def = 55;
        if (Def > Max) Def = Max;
        PhysAtk = 100;
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk =  130;
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 95;
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 75;
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
            MaxHP += healthperlvl;
            MaxMana += 15;
            Speed += 5;
            Def += 3;
            PhysAtk += 4;
            MagicAtk += 7;
            MagicDef += 5;
            Evasion += 5;
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
            GetComponent<SpriteRenderer>().sprite = Die;
            this.gameObject.tag = "Untagged";
            GetComponent<Transform>().localScale = new Vector3(9, 9, 0);
            anim.enabled = false;
            if (logic != null)
                if (logic.GetComponent<BattleStartup>().order < logic.GetComponent<BattleStartup>().inOrder.Length)
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
        if (t==2)
        {
            t = 0;
        }
        if (skilltree1[3] == true)
        {
            if (Form == 1 && HP < current)
            {
                DamageDone(Flick);
            }
            current = HP;
        }
        if (skilltree3[3] == true)
        {
            if (Form == 3 && HP < current && l<5)
            {
                PhysAtk += (int)(PhysAtk * 0.05);
                MagicAtk += (int)(MagicAtk * 0.05);
                l++;
            }
            current = HP;
        }
        if (skilltree3[7] == true)
        {
            if (logic != null)
                if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name && t==0)
                {
                    HP += MaxHP / 5;
                    t++;
                }
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
            t++;
        }
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void F1()
    {
        DamageDone(SkeirnaFiernie);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void D()
    {
        DamageDone(Drain);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void E1()
    {
        DamageDone(EctieneZrakan);
        t++;
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void I1()
    {
        DamageDone(SolneIcante);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void BS()
    {
        Mana -= 30;
        int t=Random.Range(1, 5);
        for (int i = 0; i < t; i++)
        {
            DamageDone(BladeStorm);
        }
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void DI()
    {
        HP -= MaxHP / 3;
        Mana -= 30;
        target.GetComponent<CharStats>().HP -= (MaxHP/3)*2;
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void V()
    {
        DamageDone(Vampirism);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void BV() 
    {
        DamageDone(BeyondTheVeil);
        HP -= HP / 3;
        t++;
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void EV() 
    {
        DamageDone(EyesoftheVoid);
        DamageDone(EyesoftheVoid);
        HP -= HP / 2;
        t++;
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void TC() 
    {
        Mana -= 10;
        int t = Random.Range(1, 8);
        for (int i = 0; i < t; i++)
        {
            DamageDone(ThousandCuts);
        }
        logic.GetComponent<BattleStartup>().Increase();
    }
}
