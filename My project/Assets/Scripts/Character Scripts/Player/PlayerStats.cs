using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        int run = Random.Range(0, 4);
        if (run < 3)
            logic.GetComponent<BattleStartup>().Increase();
        else
            SceneManager.LoadScene("World");
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
