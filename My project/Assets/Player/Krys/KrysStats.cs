using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class KrysStats : CharStats
{
    public Animator anim;
    public int Form = 0;
    int i = 0;
    int D;
    public Sprite Dead;
    int healthperlvl = 5;
    int curve = 1;
    // Start is called before the first frame update
    void Start()
    {
        CharName = "Krys";
        position = 1;
        target = GameObject.FindGameObjectWithTag("Enemy");
        DontDestroyOnLoad(this.gameObject);
        Level = 1;
        CritDmg = 25;
        EXP = 0;
        Crit = 15;
    }

    private void Awake()
    {
        anim.SetInteger("Phase", 1);
        anim.SetBool("Martial", true);
        Form = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Logic") != null)
            logic = GameObject.FindGameObjectWithTag("Logic");
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
        if (i == 0)
        {
            HP = MaxHP;
            Mana = MaxMana;
            i++;
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
            i--;
        }
        if (HP<=0)
        {
            HP = 0;
            GetComponent<SpriteRenderer>().sprite = Dead;
            GetComponent<Transform>().localScale = new Vector3(9,9,0);
            anim.enabled = false;
            if (logic != null)
            if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name)
                logic.GetComponent<BattleStartup>().order++;
        }
        else if (HP > 0)
        {
            GetComponent<Transform>().localScale = new Vector3(26, 26, 0);
            anim.enabled = true;
        }

    }

    
    public void Attack()//Attacks will have a 2% randomization
    {
            if (Form == 1)
            {

            target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.5, 0.01, target.GetComponent<CharStats>().Def, "Knife", true);
            }
            else if (Form == 2)
            {
            target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.3, 0.01, target.GetComponent<CharStats>().Def, "Knife", true);
            }
            else
            {
            target.GetComponent<CharStats>().HP -= DamageDone(0, PhysAtk, 0.4, 0.01, target.GetComponent<CharStats>().Def, "Knife", true);
            HP += DamageDone(0, PhysAtk, 0.4, 0.01, target.GetComponent<CharStats>().Def, "Knife", true)/4;
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
        anim.SetBool("Eldritch", false);
        anim.SetBool("Martial", false);
        anim.SetBool("Mage", false);
        anim.SetInteger("Phase", 0);
    }

    public void Eldritch()
    {
        anim.SetBool("Eldritch", true);
        anim.SetBool("Martial", false);
        anim.SetBool("Mage", false);
        Form = 3;
        HP -= MaxHP / 4;
    }

    public void Martial()
    {
        anim.SetBool("Eldritch", false);
        anim.SetBool("Martial", true);
        anim.SetBool("Mage", false);
        Form=1;
    }

    public void Mage()
    {
        anim.SetBool("Eldritch", false);
        anim.SetBool("Martial", false);
        anim.SetBool("Mage", true);
        Form=2;
    }

    public void FireBall()
    {
        target.GetComponent<CharStats>().HP -= DamageDone(50, MagicAtk, 0.4, 0.08, target.GetComponent<CharStats>().MagicDef, "Fire", false);
        Mana -= 10;
        logic.GetComponent<BattleStartup>().order++;
    }

    public void Drain()
    {
        D += DamageDone(5, PhysAtk, 0.4, 0.08, target.GetComponent<CharStats>().Def, "Knife", true);
        target.GetComponent<CharStats>().HP -= D;
        if (HP + D / 4 > MaxHP)
        {
            HP = MaxHP;
        }
        else
        HP += D / 4;
        Mana -= 7;
        logic.GetComponent<BattleStartup>().order++;
    }
}
