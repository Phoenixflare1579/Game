using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : CharStats
{
    PlayerStats MC;
    public string item;
    public CharStats user;
    void Start()
    {
        MC = GameObject.Find("MC").GetComponent<PlayerStats>();
        //find user from parent input class.
    }
    private void Update()
    {
        target = MC.target;
    }

    public void Use()
    {
        if (item == "B")
        {
            DamageDone(Bomb);
            MC.Consumables["Bomb"]--;
        }
        else if (item == "P") 
        {
            DamageDone(Potion);
            MC.Consumables["Potion"]--;
        }
        else if (item == "MP")
        {
            DamageDone(Multipotion);
            MC.Consumables["Multipotion"]--;
        }
        else if (item == "TK")
        {
            DamageDone(ThrowingKnife);
            MC.Consumables["ThrowingKnife"]--;
        }
    }
}
