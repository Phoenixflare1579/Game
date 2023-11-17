using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class CharStats : MonoBehaviour
{
    public GameObject target;
    public int HP;
    public int MaxHP;
    public int Speed;
    public const int Max = 999;
    public int Def;
    public int PhysAtk;
    public int MagicAtk;
    public int MagicDef;
    public int MaxMana;
    public int Mana;
    public int Evasion;
    public int Accuracy;
    public int Crit = 100;
    public int CritDmg = 25;
    public const int CritMax = 100;
    public int Level;
    public int EXP;
    public int EXPMax;
    public string CharName;
    public int position;
    public bool isTarget = false;
    public int skillpoints=0;
    public int skillperlvl=1;
    public GameObject logic;
    public Dictionary<string, bool> weaknesses = new Dictionary<string, bool>();
    public Dictionary<Consumable, bool> Consumables = new Dictionary<Consumable, bool>();
    public Equipment[] Equipped;
    public Attacks[] Attacks;
    public GameObject damageindicatorP;
    GameObject holder;
    public int Dead = 0;

    // Attacks//
    public Attacks BasicAttack = new Attacks(0, 0, 0, 0, 0, 0, 0, false, string.Empty, true, false);
    public Attacks Dagger = new Attacks(0, 0, 0, 0, 0, 0, 0, false, string.Empty, true, false);
    // Attacks//
    public void DamageDone(Attacks attack)
    {
        holder = Instantiate(damageindicatorP);
        HP -= attack.HPCost;
        Mana -= attack.MPCost;

        if (attack.AOE)
        {
            string tag = target.gameObject.tag;

            for (int i = 0; i < GameObject.FindGameObjectsWithTag(tag).Length; i++)
            {
                target = GameObject.FindGameObjectsWithTag(tag)[i];
                Damage(attack);
            }
        }
        else
        {
            Damage(attack);
        }

        target.GetComponent<CharStats>().HP += attack.Healing;
    }

    public void Damage(Attacks attack)
    {
        int DmgStat = 0;
        int DefStat = 0;
        if (target.GetComponent<CharStats>().Evasion * Random.Range((float).75, (float)1.0) <= Accuracy * Random.Range((float).75, (float)1.0))
        {
            if (attack.isPhysAtk)
            {
                DmgStat = PhysAtk;
                DefStat = target.GetComponent<CharStats>().Def;
            }
            else if (attack.isMagicAtk)
            {
                DmgStat = MagicAtk;
                DefStat = target.GetComponent<CharStats>().MagicDef;
            }

            double normDmg = attack.BaseDmg + (Random.Range(0.98f, 1.02f) * (DmgStat * (attack.BaseDmgScale + (attack.LevelDmgAmount * Level)) - DefStat * 0.25));
            if (Random.Range((float)0.0, (float)1.0) <= (float)(Crit / 100.0) && attack.isPhysAtk)
            {
                normDmg += normDmg * CritDmg / 100;
                holder.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(125, 125, 0, 255);
            }
            if (target.GetComponent<CharStats>().weaknesses.ContainsKey(attack.DamageType))
            {
                normDmg += normDmg * 0.2;
                holder.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);
            }
            holder.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = " " + (int)normDmg;
            holder.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);

            target.GetComponent<CharStats>().HP -= (int)normDmg;
            if (attack.PercentLifeSteal != 0)
            {
                HP += (int)(attack.PercentLifeSteal * normDmg);
            }
        }
    }

    public void OnMouseDown()
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "Player")
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<CharStats>().isTarget = false;
                
            }
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<CharStats>().isTarget = false;

            }
            gameObject.GetComponent<CharStats>().isTarget = true;
        }
    }
    
    public GameObject generateTarget()
    {
        GameObject HoldTarget = GameObject.FindGameObjectsWithTag("Enemy")[0];

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<CharStats>().isTarget)
            {
                HoldTarget = GameObject.FindGameObjectsWithTag("Enemy")[i];
            }
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<CharStats>().isTarget)
            {
                HoldTarget = GameObject.FindGameObjectsWithTag("Player")[i];
            }
        }

        return HoldTarget;
    }
    public void FindLogic()
    {
        logic = GameObject.FindGameObjectWithTag("Logic");
    }
    public void AddEquipment(Equipment[] equipment)
    {

    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }
}
