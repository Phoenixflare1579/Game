using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MCStats : PlayerStats
{
    public Vector3 Location;
    public string scene;
    public Sprite Die;
    bool followup = false;
    int c = 0;
    int f = 0;
    public int b = 0;
    public int dd = 0;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState();
        CharName = "???";
        position = 0;
        Location = this.gameObject.transform.position;
        scene = string.Empty;
        DontDestroyOnLoad(this.gameObject);
        Level = 1;
        EXP = 0;
        healthperlvl = 8;
        CritDmg = 25;
        Crit = 15;
        bonuses = new int[10];
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
        MaxMana = 50;
        Speed = 90;
        if (Speed > Max) Speed = Max;
        Def = 65;
        if (Def > Max) Def = Max;
        PhysAtk = 120 + bonuses[4];
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk = 85 + bonuses[5];
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 60;
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 60;
        if (Evasion > Max) Evasion = Max;
        Accuracy = 85;
        if (Accuracy > Max) Accuracy = Max;
        if (Crit > CritMax) Crit = CritMax;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Logic") != null)
            FindLogic();
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            target = generateTarget();
        else ChangeState();
        EXPMax = 10 + (20 * Level * curve);
        if (LvlUP == 0)
        {
            MaxHP += healthperlvl;
            MaxMana += 5;
            Speed += 5;
            Def += 3;
            PhysAtk += 4;
            MagicAtk += 6;
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
                healthperlvl += 5;
                curve = Level * curve;
            }
            skillpoints += skillperlvl;
            EXP -= EXPMax;
            LvlUP--;
        }
        if (Weapon == 1)
        {
            WType = "Sword";
        }
        else if (Weapon == 2)
        {
            WType = "Axe";
        }
        else if (Weapon == 3) 
        {
            WType = "Knife";
        }
        else if (Weapon == 4)
        {
            WType = "Spear";
        }
        if (HP <= 0)
        {
            HP = 0;
            GetComponent<SpriteRenderer>().sprite = Die;
            this.gameObject.tag = "Untagged";
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
            anim.enabled = true;
            this.gameObject.tag = "Player";
        }
        if (skilltree1[3]==true)
        {
            if (followup == true && Form == 1)
            {
                if (Random.Range(0f,1f)>=0.5f)
                {
                    DamageDone(BasicSword);
                }
            }
            followup = false;
        }
        if (logic != null)
        {
            if (skilltree1[7] == true && Form == 1)
            {
                int o = 0;
                if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name && c == 0)
                    if (Random.Range(0f, 1f) >= 0.8f)
                    {
                        target.GetComponent<CharStats>().Def /= 2;
                    }
                c = 1;
                if (o + 1 == logic.GetComponent<BattleStartup>().order && c == 1)
                {
                    c = 0;
                }
                o = logic.GetComponent<BattleStartup>().order;
            }
        }
        if (skilltree2[3] == true && Form == 2)
        {
            bonuses[4] = (5+Level) * 2;
            bonuses[5] = (5+Level) * 2;
        }
        if (skilltree2[7] == true && Form == 2)
        {
            int o = 0;
            if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name && c == 0)
                if (Random.Range(0f, 1f) >= 0.5f)
                {
                    DamageDone(SpellBlade);
                }
            c = 1;
            if (o+1==logic.GetComponent<BattleStartup>().order && c == 1)
            {
                c = 0;
            }
            o = logic.GetComponent<BattleStartup>().order;
        }
        if (skilltree3[3] == true)
        {
            bonuses[1] = 20;
        }
        if (skilltree3[7] == true)
        {
            if (target.GetComponent<CharStats>().HP < target.GetComponent<CharStats>().MaxHP/2)
            {
                bonuses[9] = 25;
            }
            else if (target.GetComponent<CharStats>().HP < target.GetComponent<CharStats>().MaxHP /10)
            {
                DamageDone(Execution);
            }
        }
        if (Form == 3)
        {
            Def /= 2;
            MagicDef /= 2;
            PhysAtk = (int)(1.5 * PhysAtk);
            MagicAtk = (int)(1.5 * MagicAtk);
            f = 1;
        }
        else
        {
            if (f == 1) 
            {
                Def *= 2;
                MagicDef *= 2;
                PhysAtk = (int)(PhysAtk/1.5);
                MagicAtk = (int)(MagicAtk/1.5);
                f = 0;
            }
        }
    }

    public void Attack()//Attacks will have a 2% randomization
    {
            if (Form == 1)
            {
                DamageDone(BasicSword);
                followup = true;
            }
            else if (Form == 2)
            {
                DamageDone(BasicSword);
            }
            else
            {
                DamageDone(BasicSword);
            }
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void C()
    {
        DamageDone(Cleave);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void EX()
    {
        DamageDone(Experimentation);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void PS()
    {
        DamageDone(PiercingStrike);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void CS()
    {
        DamageDone(CrossStrike);
        DamageDone(CrossStrike);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void BS()
    {
        DamageDone(Backstab);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void S() 
    {
        DamageDone(Sweep);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void BW()
    {
        DamageDone(Bladewhirl);
        DamageDone(Bladewhirl);
        DamageDone(Bladewhirl);
        logic.GetComponent<BattleStartup>().Increase();
    }
    public void GS()
    {
        DamageDone(GuillotineStrike);
        logic.GetComponent<BattleStartup>().Increase();
    }
}
