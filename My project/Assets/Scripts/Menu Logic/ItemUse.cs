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
        target = user.target;
    }

    public void Use()
    {
        if (item == "B")
        {
            DamageDone(Bomb);
            //MC.Consumables.Remove();
        }
        else if (item == "P") 
        {
            DamageDone(Potion);
            //MC.Consumables.Remove(Potion);
        }
        else if (item == "MP")
        {
            DamageDone(Multipotion);
            //MC.Consumables.Remove(Multipotion);
        }
        else if (item == "TK")
        {
            DamageDone(ThrowingKnife);
            //MC.Consumables.Remove(ThrowingKnife);
        }
    }
}
