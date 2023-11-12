using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MCStats : PlayerStats
{
    public Vector3 Location;
    public Sprite Die;
    Dictionary<string,int> inventory = new Dictionary<string,int>();
    // Start is called before the first frame update
    void Start()
    {
        ChangeState();
        CharName = "???";
        position = 0;
        Location = this.gameObject.transform.position;
        DontDestroyOnLoad(this.gameObject);
        Level = 1;
        EXP = 0;
        healthperlvl = 8;
        CritDmg = 25;
        Crit = 100;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Logic") != null)
            FindLogic();
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            target = generateTarget();
        else ChangeState();
        MaxHP = 120 + (healthperlvl * Level);
        MaxMana = 50 + (5 * Level);
        Speed = 90 + (5 * Level);
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

    public void Attack()//Attacks will have a 2% randomization
    {
            if (Form == 1)
            {
                target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.5, 0.01, target.GetComponent<CharStats>().Def, WType, true);
            }
            else if (Form == 2)
            {
                target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.7, 0.01, target.GetComponent<CharStats>().Def, WType, true);
            }
            else
            {
                target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.4, 0.01, target.GetComponent<CharStats>().Def, WType, true);
            }
        logic.GetComponent<BattleStartup>().Increase();
    }
}
