using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject damageindicatorP;
    GameObject holder;
    public int Dead = 0;
    public int DamageDone(double BaseDmg, double DmgStat, double BaseDmgScale, double LevelDmgAmount, double DefStat, string type, bool isNotMagic/*, GameObject Object*/)
    {
        holder = Instantiate(damageindicatorP);
        double normDmg = BaseDmg + (Random.Range(0.98f, 1.02f) * (DmgStat * (BaseDmgScale + (LevelDmgAmount * Level)) - DefStat * 0.25));
        if (Random.Range(0, 1) >= 100-Crit / 100 && isNotMagic)
        { 
            normDmg += normDmg * CritDmg/100;
            holder.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255,0,0,255);
        }
        if (target.GetComponent<CharStats>().weaknesses.ContainsKey(type))
        {
            normDmg += normDmg * 0.2;
            holder.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(0,255,0,255);
        }
        holder.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = " " + (int)normDmg;
        holder.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y,target.transform.position.z);
        return (int)normDmg;
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
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }
}
