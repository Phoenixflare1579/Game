using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MCStats : CharStats
{
    public Vector3 Location;
    public Animator anim;
    public int Form = 0;
    public int Weapon = 1;
    public string WType = string.Empty;
    int i = 0;
    public Sprite Dead;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MC Stats");
        ChangeState();
        CharName = "???";
        position = 0;
        Location = this.gameObject.transform.position;
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
        if (EXP >= EXPMax)
        {
            Level++;
            EXP -= EXPMax;
            i--;
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
            GetComponent<SpriteRenderer>().sprite = Dead;
            anim.enabled = false;
            if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order][0] ==this.gameObject.name)
            logic.GetComponent<BattleStartup>().order++;
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
        Weapon = 0;
        anim.SetInteger("Weapon", Weapon);
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
}
