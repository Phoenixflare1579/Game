using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class KrysStats : CharStats
{
    public Animator anim;
    public int Form = 0;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        CharName = "Krys";
        position = 1;
        target = GameObject.FindGameObjectWithTag("Enemy");
        DontDestroyOnLoad(this.gameObject);
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
        if (logic != null)
            logic = GameObject.FindGameObjectWithTag("Logic");
        if (target != null)
            target = GameObject.FindGameObjectWithTag("Enemy");
        if (target == null)
        {
            ChangeState();
        }
        MaxHP = 120 + (5 * Level);
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
                target.GetComponent<EnemyStats>().HP -= (int)((PhysAtk * (0.5 + (0.01 * Level))) + (Random.Range(-0.02f, 0.02f) * (PhysAtk * 0.5 + (0.01 * Level))));
            }
            else if (Form == 2)
            {
                target.GetComponent<EnemyStats>().HP -= (int)((PhysAtk * (0.3 + (0.01 * Level))) + (Random.Range(-0.02f, 0.02f) * (PhysAtk * 0.3 + (0.01 * Level))));
            }
            else
            {
                target.GetComponent<EnemyStats>().HP -= (int)((PhysAtk * (0.4 + (0.01 * Level))) + (Random.Range(-0.02f, 0.02f) * (PhysAtk * 0.4 + (0.01 * Level))));
            }
        }
        logic.GetComponent<BattleStartup>().order++;
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
}
