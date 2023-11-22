using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.GraphicsBuffer;

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
    public GameObject damageindicatorP;
    public GameObject[] animations; 
    GameObject holder;
    GameObject hold;
    public int Dead = 0;

    public class Attacks
    {
        public double BaseDmg;
        public double BaseDmgScale;
        public double LevelDmgAmount;
        public double Healing;
        public int MPCost;
        public double HPCost;
        public double PercentLifeSteal;
        public bool AOE;
        public string DamageType;
        public bool isPhysAtk;
        public bool isMagicAtk;
        public Attacks(double BaseDmgC, double BaseDmgScaleC, double LevelDmgAmountC, double HealingC, int MPCostC, double HPCostC, double PercentLifeStealC, bool AOEC, string DamageTypeC, bool isPhysAtkC, bool isMagicAtkC)
        {
            BaseDmg = BaseDmgC;
            BaseDmgScale = BaseDmgScaleC;
            LevelDmgAmount = LevelDmgAmountC;
            Healing = HealingC;
            MPCost = MPCostC;
            HPCost = HPCostC;
            PercentLifeSteal = PercentLifeStealC;
            AOE = AOEC;
            DamageType = DamageTypeC;
            isPhysAtk = isPhysAtkC;
            isMagicAtk = isMagicAtkC;
        }
    }

    // Attacks//
    public Attacks BasicSword = new Attacks(0, 0.5, 0.05, 0, 0, 0, 0, false, "Sword", true, false);
    public Attacks BasicDagger = new Attacks(0, 0.5, 0.05, 0, 0, 0, 0, false, "Knife", true, false);
    public Attacks BasicSpear = new Attacks(0, 0.5, 0.05, 0, 0, 0, 0, false, "Spear", true, false);
    public Attacks BasicAxe = new Attacks(0, 0.5, 0.05, 0, 0, 0, 0, false, "Axe", true, false);
    public Attacks BasicStaff = new Attacks(0, 0.5, 0.05, 0, 0, 0, 0, false, "Staff", true, false);
    public Attacks Bite = new Attacks(0, 0.6, 0.03, 0, 0, 0, 0.25, false, "Knife", true, false);
    public Attacks Drain = new Attacks(0, 0.6, 0.06, 0, 0, 0, 0.25, false, "Knife", true, false);
    public Attacks Rampage = new Attacks(10, 0.6, 0.08, 0 , 0, 0.1, 0, false, "Staff", true, false);
    public Attacks WildRush = new Attacks(0, 0.3, 0.05, 0, 0, 0, 0, false, "Staff", true, false);
    public Attacks ClawSwipe = new Attacks(0, 0.6, 0.05, 0, 0, 0, 0, false, "Sword", true, false);
    public Attacks HornSlam = new Attacks(0, 0.3, 0.05, 0, 0, 0, 0, true, "Staff", true, false);
    public Attacks Eat = new Attacks(0, 0, 0, 0.25, 50, 0, 0, false, "Sword", true, false);
    public Attacks Crunch = new Attacks(10, 0.3, 0.03, 0, 50, 0, 0, false, "Knife", false, false);
    public Attacks SkeirnaFiernie = new Attacks(20, 0.6, 0.08, 0, 15, 0, 0, false, "Fire", false, true);
    public Attacks SolneIcante = new Attacks(20, 0.6, 0.08, 0, 15, 0, 0, false, "Ice", false, true);
    public Attacks EctieneZrakan = new Attacks(20, 0.6, 0.08, 0, 15, 0, 0, false, "Lightning", false, true);
    public Attacks HolyLight = new Attacks(20, 0.6, 0.08, 0, 15, 0, 0, false, "Light", false, true);
    public Attacks Darkness = new Attacks(20, 0.6, 0.08, 0, 10, 0.1, 0, false, "Darkness", false, true);
    public Attacks ESkeirnaFiernie = new Attacks(20, 0.6, 0.08, 0, 0, 0, 0, false, "Fire", false, true);
    public Attacks ESolneIcante = new Attacks(20, 0.6, 0.08, 0, 0, 0, 0, false, "Ice", false, true);
    public Attacks EEctieneZrakan = new Attacks(20, 0.6, 0.08, 0, 0, 0, 0, false, "Lightning", false, true);
    public Attacks EHolyLight = new Attacks(20, 0.6, 0.08, 0, 0, 0, 0, false, "Light", false, true);
    public Attacks EDarkness = new Attacks(20, 0.6, 0.08, 0, 0, 0.1, 0, false, "Darkness", false, true);
    public Attacks BeyondTheVeil = new Attacks(30, 0.6, 0.08, 0, 0, 0, 0, false, "Lightning", false, true);
    public Attacks Heal = new Attacks(0, 0, 0, 0.15, 15, 0, 0, false, "Light", false, true);
    public Attacks EHeal = new Attacks(0, 0, 0, 0.15, 10, 0, 0, false, "Light", false, true);
    public Attacks Execution = new Attacks(9999, 0, 0, 0, 0, 0, 0, false, "Death", false, false);
    public Attacks Flick = new Attacks(10, 0.3, 0.02, 0, 0, 0, 0, false, "Knife", true, false);
    public Attacks BladeStorm = new Attacks(10, 0.4, 0.02, 0, 0, 0, 0, true, "Knife", true, false);
    public Attacks Vampirism = new Attacks(0, 0.75, 0, 0, 40, 0, 1, false, "Dark", false, true);
    // Attacks//
    public void DamageDone(Attacks attack)
    {
        holder = Instantiate(damageindicatorP);
        HP -= (int)(MaxHP*attack.HPCost);
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

        target.GetComponent<CharStats>().HP += (int)(MaxHP * attack.Healing);

        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
        if (target.GetComponent<CharStats>().HP > target.GetComponent<CharStats>().MaxHP)
        {
            target.GetComponent<CharStats>().HP = target.GetComponent<CharStats>().MaxHP;
        }
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
            else 
            {
                DmgStat = PhysAtk;
                DefStat = 0;
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
    public void Animation(string Wtype)
    {
        if (Wtype == "Sword")
        {
            hold = Instantiate(animations[0]);
            hold.transform.position=target.transform.position;
        }
        else if (Wtype == "Knife")
        {
            hold = Instantiate(animations[1]);
            hold.transform.position = target.transform.position;
        }
        else if (Wtype == "Spear")
        {
            hold = Instantiate(animations[2]);
            hold.transform.position = target.transform.position;
        }
        else if (Wtype == "Axe")
        {
            hold = Instantiate(animations[3]);
            hold.transform.position = target.transform.position;
        }
        else if (Wtype == "Staff")
        {
            hold = Instantiate(animations[4]);
            hold.transform.position = target.transform.position;
        }
        else if (Wtype == "Fire")
        {
            hold = Instantiate(animations[5]);
            hold.transform.position = this.gameObject.transform.position;
            Rigidbody rb = hold.GetComponent<Rigidbody>();
            rb.position = Vector3.MoveTowards(rb.position, target.transform.position, 10f * Time.deltaTime);

        }
        else if (Wtype == "Ice")
        {
            hold = Instantiate(animations[6]);
            hold.transform.position = this.gameObject.transform.position;
            Rigidbody rb = hold.GetComponent<Rigidbody>();
            rb.position = Vector3.MoveTowards(rb.position, target.transform.position, 10f * Time.deltaTime);
        }
        else if (Wtype == "Lightning")
        {
            hold = Instantiate(animations[7]);
            hold.transform.position = this.gameObject.transform.position;
            Rigidbody rb = hold.GetComponent<Rigidbody>();
            rb.position = Vector3.MoveTowards(rb.position, target.transform.position, 10f * Time.deltaTime);
        }
        else if (Wtype == "Light")
        {
            hold = Instantiate(animations[8]);
            hold.transform.position = this.gameObject.transform.position + new Vector3 (0,100,0);
            Rigidbody rb = hold.GetComponent<Rigidbody>();
            rb.position = Vector3.MoveTowards(rb.position, target.transform.position, 10f * Time.deltaTime);
        }
        else if (Wtype == "Dark")
        {
            hold = Instantiate(animations[9]);
            hold.transform.position = target.transform.position + new Vector3(0, -20, 0);
            Rigidbody rb = hold.GetComponent<Rigidbody>(); 
            rb.position = Vector3.MoveTowards(rb.position, target.transform.position, 5f * Time.deltaTime);
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
