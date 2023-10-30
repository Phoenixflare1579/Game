using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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
    public int Crit;
    public int CritDmg;
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

    private void Start()
    {

    }

    public int DamageDone(double BaseDmg, double DmgStat, double BaseDmgScale, double LevelDmgAmount, double DefStat, string type, bool isNotMagic/*, GameObject Object*/)
    {

        double normDmg = BaseDmg + (Random.Range(0.98f, 1.02f) * (DmgStat * (BaseDmgScale + (LevelDmgAmount * Level)) - DefStat * 0.25));
        if (Random.Range(0, 1) <= Crit / 100 && isNotMagic)
        { 
            normDmg += normDmg * CritDmg/100;
        }
        Debug.Log(target.GetComponent<CharStats>().weaknesses.ContainsKey(type));
        if (target.GetComponent<CharStats>().weaknesses.ContainsKey(type))
        {
            normDmg += normDmg * 0.2;
            Debug.Log("Weakpoint Hit!");
        }
        Debug.Log(target.GetComponent<CharStats>().HP - (int)normDmg + " " + target.name + " " + gameObject.name);
        return (int)normDmg;
    }

    public void OnMouseDown()
    {
        if (gameObject.tag == "Enemy")
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<CharStats>().isTarget = false;
                
            }
            Debug.Log(gameObject.name);
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
        return HoldTarget;
    }

}
