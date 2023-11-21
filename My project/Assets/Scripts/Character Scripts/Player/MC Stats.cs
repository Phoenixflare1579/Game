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
        Crit = 100;
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
        MaxHP = 120 + (healthperlvl * Level) + bonuses[0];
        MaxMana = 50 + (5 * Level) + bonuses[1];
        Speed = 90 + (5 * Level) + bonuses[2];
        if (Speed > Max) Speed = Max;
        Def = 65 + (3 * Level) + bonuses[3];
        if (Def > Max) Def = Max;
        PhysAtk = 120 + (4 * Level) + bonuses[4];
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk = 85 + (6 * Level) + bonuses[5];
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 60 + (5 * Level) + bonuses[6];
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 60 + (5 * Level) + bonuses[7];
        if (Evasion > Max) Evasion = Max;
        Accuracy = 85 + (5 * Level) + bonuses[8];
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
        if (skilltree1[0]== true && skilltree1[2] == false)
        {
            bonuses[4] = 10;
        }
        else if (skilltree1[2] == true)
        {
            bonuses[4] = 25;
        }
        if (skilltree1[1]==true && skilltree1[5] == false)
        {
            bonuses[2] = 10;
        }
        else if (skilltree1[5] == true)
        {
            bonuses[2] = 35;
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
        if (skilltree1[4]==true)
        {
            bonuses[0] = 50;
        }
        if (skilltree1[6]==true)
        {
            bonuses[8] = 30;
        }
        if (skilltree1[7]==true && Form ==1)
        {
            if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name && c==0)
            if (Random.Range(0f, 1f) >= 0.8f)
            {
                target.GetComponent<CharStats>().Def /= 2;
            }
            c = 1;
        }
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name && c == 1)
        {
            c = 0;
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
            bonuses[4] += Level * 2;
            bonuses[5] += Level * 2;
        }
        if (skilltree2[4] == true)
        {
            bonuses[0] = 50;
        }
        if (skilltree2[6] == true)
        {
            bonuses[7] = 30;
        }
        if (skilltree2[7] == true && Form == 2)
        {
            int P = PhysAtk;
            PhysAtk += MagicAtk/2;
            MagicAtk += P/2;
        }
        if (skilltree3[0] == true && skilltree3[2] == false)
        {
            bonuses[4] = 10;
        }
        else if (skilltree3[2] == true)
        {
            bonuses[4] = 25;
        }
        if (skilltree3[1] == true && skilltree3[5] == false)
        {
            bonuses[5] = 10;
        }
        else if (skilltree3[5] == true)
        {
            bonuses[5] = 35;
        }
        if (skilltree3[3] == true)
        {
            bonuses[1] = 20;
        }
        if (skilltree3[4] == true)
        {
            bonuses[0] = 50;
        }
        if (skilltree3[6] == true)
        {
            Crit += 5;
        }
        if (skilltree3[7] == true)
        {
            Crit += 10;
            CritDmg += 15;
            if (target.GetComponent<CharStats>().HP < target.GetComponent<CharStats>().MaxHP/2)
            {
                Crit += 35;
            }
            else if (target.GetComponent<CharStats>().HP < target.GetComponent<CharStats>().MaxHP /10)
            {
                DamageDone(Execution);
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
}
