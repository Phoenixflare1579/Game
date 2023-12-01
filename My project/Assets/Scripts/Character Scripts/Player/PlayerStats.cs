using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerStats : CharStats
{

    public int Weapon = 1;
    public int Form = 0;
    public Dictionary<string, int> Consumables = new Dictionary<string, int>();
    public Animator anim;
    public string WType = string.Empty;
    public int healthperlvl;
    public int curve = 1;
    public int LvlUP = 0;
    public bool[] skilltree1;
    public bool[] skilltree2;
    public bool[] skilltree3;
    public int[] bonuses;
    bool defend = false;
    int magdef;
    int def;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void FixedUpdate()
    {
        if (defend && logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] == this.gameObject.name) 
        {
            Def -= def;
            MagicDef -= magdef;
        }
    }
    public void Defend()
    {
        def = (int)(Def * 1.5);
        magdef = (int)(MagicDef * 1.5);
        Def += def;
        MagicDef += magdef;
        logic.GetComponent<BattleStartup>().Increase();
        defend = true;
    }
    public void Flee()
    {
        string Location = GameObject.Find("MC").GetComponent<MCStats>().scene;
        int run = Random.Range(0, 4);
        if (run < 3)
            logic.GetComponent<BattleStartup>().Increase();
        else
        {
            GameObject MC = GameObject.Find("MC");
            GameObject Krys = GameObject.Find("Krys");
            SceneManager.LoadScene(MC.GetComponent<MCStats>().scene);
            MC.gameObject.transform.position = MC.GetComponent<MCStats>().Location;
            MC.GetComponent<PlayerInput>().ActivateInput();
            MC.GetComponent<Rigidbody>().isKinematic = false;
            Krys.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Counter").GetComponent<Battle>().UnSafe();
            GameObject.FindGameObjectWithTag("Counter").GetComponent<Battle>().Restart();

        }
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
    public void ChangeState()
    {
        Weapon = 0;
        anim.SetInteger("Weapon", Weapon);
    }
    public void ChangeForm(int F)
    {
        Form = F;
        anim.SetInteger("Form", Form);
    }
}
