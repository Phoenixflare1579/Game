using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        if (logic != null)
        logic = GameObject.FindGameObjectWithTag("Logic");
        if (target != null)
        target = GameObject.FindGameObjectWithTag("Enemy");
        MaxHP = 120;
        MaxMana = 50;
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
        Level = 1;
        EXP = 0;
        EXPMax = 100 + (200 * Level);
        if (i == 0)
        {
            HP = MaxHP;
            Mana = MaxMana;
            i++;
        }
    }

    public void Attack(InputAction.CallbackContext c)//Attacks will have a 2% randomization
    {
        if (target == null) return;
        if (c.started)
        {
            if (Form == 1)
            {
                target.GetComponent<EnemyStats>().HP -= (int)((PhysAtk * (0.5 + (0.01 * Level))) + (Random.Range(-0.02f, 0.02f) * (PhysAtk * 0.5 + (0.01 * Level)))-target.GetComponent<EnemyStats>().Def*0.25);
            }
            else if (Form == 2)
            {
                target.GetComponent<EnemyStats>().HP -= (int)((PhysAtk * (0.7 + (0.01 * Level))) + (Random.Range(-0.02f, 0.02f) * (PhysAtk * 0.3 + (0.01 * Level))) - target.GetComponent<EnemyStats>().Def * 0.25);
            }
            else
            {
                target.GetComponent<EnemyStats>().HP -= (int)((PhysAtk * (0.4 + (0.01 * Level))) + (Random.Range(-0.02f, 0.02f) * (PhysAtk * 0.4 + (0.01 * Level))) - target.GetComponent<EnemyStats>().Def * 0.25);
            }
        }
        logic.GetComponent<BattleStartup>().order++;
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
}
