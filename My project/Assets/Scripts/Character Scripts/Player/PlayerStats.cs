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
    public Animator anim;
    public string WType = string.Empty;
    public int healthperlvl;
    public int curve = 1;
    public int LvlUP = 0;
    public int[] skilltree1;
    public int[] skilltree2;
    public int[] skilltree3;
    public int[] bonuses;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Defend()
    {
        Def *= (int)(Def * 1.5);
        MagicDef *= (int)(MagicDef * 1.5);
        logic.GetComponent<BattleStartup>().Increase();
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
