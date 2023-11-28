using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesS : MonoBehaviour
{
    PlayerStats Char;

    private void Update()
    {
        if (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuKrysS>() != null)
        Char = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuKrysS>().Krys.GetComponent<PlayerStats>();
        else if (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuMCS>() != null)
        Char = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuMCS>().MC.GetComponent<PlayerStats>();
        else if (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuJohannaS>() != null)
        Char = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuJohannaS>().Johanna.GetComponent<PlayerStats>();
    }
    public void Ability()
    {
        
        if (Char.gameObject.name == "Krys")
        {
            this.gameObject.transform.GetChild(Char.Form).gameObject.SetActive(true);
            if (Char.Level < 5)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(2).gameObject.SetActive(false);
            }
            if (Char.skilltree1[7]==false) 
            { 
                gameObject.transform.GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);
            }
            if (Char.skilltree2[3] == false)
            {
                gameObject.transform.GetChild(2).GetChild(0).GetChild(2).gameObject.SetActive(false);
            }
            if (Char.skilltree2[7] == false)
            {
                gameObject.transform.GetChild(2).GetChild(0).GetChild(3).gameObject.SetActive(false);
            }
            if (Char.Mana < 30)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).GetChild(0).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(2).gameObject.SetActive(false);
            }
            if (Char.Mana < 40)
            {
                gameObject.transform.GetChild(2).GetChild(0).GetChild(3).gameObject.SetActive(false);
            }
            if (Char.Mana < 15)
            {
                gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
            }
            if (Char.Mana < 10)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (Char.gameObject.name == "MC")
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            if (Char.Level < 5)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(3).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(4).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(5).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(6).gameObject.SetActive(false);
            }
            if (Char.skilltree3[3] == false)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(7).gameObject.SetActive(false);
            }
            if (Char.Mana < 30)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(4).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(7).gameObject.SetActive(false);
            }
            if (Char.Mana < 15)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(3).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(6).gameObject.SetActive(false);
            }
            if (Char.Mana < 20)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(5).gameObject.SetActive(false);
            }
            if (Char.Mana < 10)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
            }
            if (Char.Form != 3)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(6).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(7).gameObject.SetActive(false);
            }
        }
        else if (Char.gameObject.name == "Johanna")
        {
            this.gameObject.transform.GetChild(Char.Form).gameObject.SetActive(true);
            if (Char.Level < 5)
            {
                gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).GetChild(0).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(3).gameObject.SetActive(false);
            }
            if (Char.skilltree2[7] == false)
            {
                gameObject.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(false);
            }
            if (Char.Mana < 30)
            {
                gameObject.transform.GetChild(3).GetChild(0).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(false);
            }
            if (Char.Mana < 15)
            {
                gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).GetChild(0).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(3).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
            }
            if (Char.Mana < 10)
            {
                gameObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
