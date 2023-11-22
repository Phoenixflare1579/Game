using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JohannaStats : PlayerStats
{
    public Sprite Die;
    // Start is called before the first frame update
    void Start()
    {
        CharName = "Johanna";
        position = 2;
        target = GameObject.FindGameObjectWithTag("Enemy");
        DontDestroyOnLoad(this.gameObject);
        Level = 1;
        EXP = 0;
        WType = "Spear";
        healthperlvl = 8;
        anim.SetInteger("Phase", 1);
        Form = 1;
        anim.SetInteger("Form", Form);
        CritDmg = 25;
        Crit = 15;
        bonuses = new int[9];
        skilltree1 = new bool[9];
        skilltree2 = new bool[9];
        skilltree3 = new bool[9];
        for (int i = 0; i < 9; i++)
        {
            skilltree1[i] = false;
            skilltree2[i] = false;
            skilltree3[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Logic") != null)
            FindLogic();
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            target = generateTarget();
        else ChangeState();
        MaxHP = (105 + (healthperlvl * Level)) + bonuses[0];
        MaxMana = 80 + (12 * Level) + bonuses[1];
        Speed = 130 + (5 * Level) + bonuses[2];
        if (Speed > Max) Speed = Max;
        Def = 70 + (6 * Level) + bonuses[3];
        if (Def > Max) Def = Max;
        PhysAtk = 80 + (5 * Level) + bonuses[4];
        if (PhysAtk > Max) PhysAtk = Max;
        MagicAtk = 100 + (6 * Level) + bonuses[5];
        if (MagicAtk > Max) MagicAtk = Max;
        MagicDef = 90 + (5 * Level) + bonuses[6];
        if (MagicDef > Max) MagicDef = Max;
        Evasion = 60 + (3 * Level) + bonuses[7];
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
            this.gameObject.tag = "Untagged";
            GetComponent<SpriteRenderer>().sprite = Die;
            anim.enabled = false;
            if (logic != null)
                if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name)
                    logic.GetComponent<BattleStartup>().Increase();
            if (SceneManager.GetActiveScene().name != "Combat")
            {
                HP = 1;
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
                if (Form == 1)
                {

                }
            }
            if (skilltree1[4] == true)
            {
                bonuses[0] = 50;
            }
            if (skilltree1[6] == true)
            {
                bonuses[8] = 30;
            }
            if (skilltree1[7] == true && Form == 1)
            {

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

            }
            if (skilltree3[7] == true)
            {

            }
        }
        else if (HP > 0)
        {
            anim.enabled = true;
            this.gameObject.tag = "Player";
        }
    }
}
