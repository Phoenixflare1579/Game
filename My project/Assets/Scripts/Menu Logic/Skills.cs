using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public int Form = 1;
    public int Branch=1;
    public int SP = 1;
    public PlayerStats Char;
    string C;

    private void Start()
    {
        C = gameObject.transform.parent.parent.parent.GetChild(0).gameObject.GetComponent<SkillPoints>().C;
        Char = GameObject.Find(C).GetComponent<PlayerStats>();
    }
    public void Update() 
    {

        if (Form == 1 && Char.skilltree1[Branch] == true)
        {
            gameObject.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (Form == 2 && Char.skilltree2[Branch] == true)
        {
            gameObject.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (Form == 3 && Char.skilltree3[Branch] == true)
        {
            gameObject.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (Char.skillpoints < SP)
        {
            gameObject.GetComponent<Image>().color = new Color32(84, 84, 84, 255);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (Form == 3 && ((Branch != 0 && Char.skilltree3[Branch - 1] != true) || (Branch == 3 && Char.skilltree3[Branch - 1] != true && Char.skilltree3[Branch - 2] != true) || (Branch == 6 && Char.skilltree3[Branch - 1] != true && Char.skilltree3[Branch - 2] != true)))
                {
            gameObject.GetComponent<Image>().color = new Color32(84, 84, 84, 255);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (Form == 1 && ((Branch != 0 && Char.skilltree1[Branch - 1] != true) || (Branch == 3 && Char.skilltree1[Branch - 1] != true && Char.skilltree1[Branch - 2] != true) || (Branch == 6 && Char.skilltree1[Branch - 1] != true && Char.skilltree1[Branch - 2] != true)))
        {
            gameObject.GetComponent<Image>().color = new Color32(84, 84, 84, 255);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (Form == 2 && ((Branch != 0 && Char.skilltree2[Branch - 1] != true) || (Branch == 3 && Char.skilltree2[Branch - 1] != true && Char.skilltree2[Branch - 2] != true) || (Branch == 6 && Char.skilltree2[Branch - 1] != true && Char.skilltree2[Branch - 2] != true)))
        {
            gameObject.GetComponent<Image>().color = new Color32(84, 84, 84, 255);
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void Unlock()
    {
        if (Form == 1)
        {
            if (Char.skillpoints >= SP && Char.skilltree1[Branch] != true)
            {
                Debug.Log(Branch);
                /*if ((Branch != 0 && Char.skilltree1[Branch - 1] == true) || (Branch == 3 && Char.skilltree1[Branch - 1] == true || Char.skilltree1[Branch - 2] == true) || (Branch == 6 && Char.skilltree1[Branch - 1] == true || Char.skilltree1[Branch - 2] == true))
                {*/
                    Char.skilltree1[Branch] = true;
                    Char.skillpoints -= SP;
                    if (Char.gameObject.name == "MC")
                    {
                        if (Branch == 0)
                        {
                            Char.PhysAtk += 15;
                        }
                        else if (Branch == 1)
                        {
                            Char.Speed += 10;
                        }
                        else if (Branch == 2)
                        {
                            Char.PhysAtk += 25;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxHP += 50;
                        }
                        else if (Branch == 5)
                        {
                            Char.Speed += 20;
                        }
                        else if (Branch == 6)
                        {
                            Char.Accuracy += 30;
                        }
                    }
                    else if (Char.gameObject.name == "Krys")
                    {
                        if (Branch == 0)
                        {
                            Char.PhysAtk += 15;
                        }
                        else if (Branch == 1)
                        {
                            Char.Speed += 10;
                        }
                        else if (Branch == 2)
                        {
                            Char.PhysAtk += 25;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxMana += 30;
                        }
                        else if (Branch == 5)
                        {
                            Char.Speed += 20;
                        }
                        else if (Branch == 6)
                        {
                            Char.Accuracy += 30;
                        }
                    }
                    else if (Char.gameObject.name == "Johanna")
                    {
                        if (Branch == 0)
                        {
                            Char.PhysAtk += 15;
                        }
                        else if (Branch == 1)
                        {
                            Char.Speed += 10;
                        }
                        else if (Branch == 2)
                        {
                            Char.PhysAtk += 25;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxHP += 50;
                        }
                        else if (Branch == 5)
                        {
                            Char.Speed += 20;
                        }
                        else if (Branch == 6)
                        {
                            Char.Accuracy += 30;
                        }
                    }
                
            }
        }
        else if (Form == 2) 
        {
            if (Char.skillpoints >= SP && Char.skilltree2[Branch] != true)
            {
                /*if ((Branch != 0 && Char.skilltree2[Branch - 1] == true) || (Branch == 3 && Char.skilltree2[Branch - 1] == true || Char.skilltree2[Branch - 2] == true) || (Branch == 6 && Char.skilltree2[Branch - 1] == true || Char.skilltree2[Branch - 2] == true))
                {*/
                    Char.skilltree2[Branch] = true;
                    Char.skillpoints -= SP;
                    if (Char.gameObject.name == "MC")
                    {
                        if (Branch == 0)
                        {
                            Char.MagicAtk += 15;
                        }
                        else if (Branch == 1)
                        {
                            Char.MagicDef += 10;
                        }
                        else if (Branch == 2)
                        {
                            Char.MagicAtk += 25;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxHP += 50;
                        }
                        else if (Branch == 5)
                        {
                            Char.MagicDef += 20;
                        }
                        else if (Branch == 6)
                        {
                            Char.Evasion += 30;
                        }
                    }
                    else if (Char.gameObject.name == "Krys")
                    {
                        if (Branch == 0)
                        {
                            Char.MagicAtk += 15;
                        }
                        else if (Branch == 1)
                        {
                            Char.Evasion += 10;
                        }
                        else if (Branch == 2)
                        {
                            Char.MagicAtk += 25;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxMana += 30;
                        }
                        else if (Branch == 5)
                        {
                            Char.Evasion += 20;
                        }
                        else if (Branch == 6)
                        {
                            Char.Evasion += 30;
                        }
                    }
                    else if (Char.gameObject.name == "Johanna")
                    {
                        if (Branch == 0)
                        {
                            Char.Def += 15;
                        }
                        else if (Branch == 1)
                        {
                            Char.MagicDef += 15;
                        }
                        else if (Branch == 2)
                        {
                            Char.Def += 25;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxHP += 50;
                        }
                        else if (Branch == 5)
                        {
                            Char.MagicDef += 25;
                        }
                        else if (Branch == 6)
                        {
                            Char.MaxMana += 30;
                        }
                    
                }
            }
        }
        else if (Form == 3)
        {
            if (Char.skillpoints >= SP && Char.skilltree3[Branch] != true)
            {
                /*if ((Branch != 0 && Char.skilltree3[Branch - 1] == true) || (Branch == 3 && Char.skilltree3[Branch - 1] == true || Char.skilltree3[Branch - 2] == true) || (Branch == 6 && Char.skilltree3[Branch - 1] == true || Char.skilltree3[Branch - 2] == true))
                {*/
                    Char.skilltree3[Branch] = true;
                    Char.skillpoints -= SP;
                    if (Char.gameObject.name == "MC")
                    {
                        if (Branch == 0)
                        {
                            Char.PhysAtk += 15;
                        }
                        else if (Branch == 1)
                        {
                            Char.MagicAtk += 10;
                        }
                        else if (Branch == 2)
                        {
                            Char.PhysAtk += 25;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxHP += 50;
                        }
                        else if (Branch == 5)
                        {
                            Char.MagicAtk += 20;
                        }
                        else if (Branch == 6)
                        {
                            Char.Crit += 5;
                        }
                        else if (Branch == 7)
                        {
                            Char.Crit += 10;
                            Char.CritDmg += 15;
                        }
                    }
                    else if (Char.gameObject.name == "Krys")
                    {
                        if (Branch == 0)
                        {
                            Char.MaxHP += 25;
                        }
                        else if (Branch == 1)
                        {
                            Char.Speed += 10;
                        }
                        else if (Branch == 2)
                        {
                            Char.MaxHP += 50;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxMana += 30;
                        }
                        else if (Branch == 5)
                        {
                            Char.Speed += 20;
                        }
                        else if (Branch == 6)
                        {
                            Char.Accuracy += 30;
                        }
                    }
                    else if (Char.gameObject.name == "Johanna")
                    {
                        if (Branch == 0)
                        {
                            Char.Evasion += 10;
                        }
                        else if (Branch == 1)
                        {
                            Char.Speed += 20;
                        }
                        else if (Branch == 2)
                        {
                            Char.Evasion += 20;
                        }
                        else if (Branch == 4)
                        {
                            Char.MaxHP += 50;
                        }
                        else if (Branch == 5)
                        {
                            Char.Speed += 40;
                        }
                        else if (Branch == 6)
                        {
                            Char.Crit += 10;
                        }
                    }
                
            }
        }
    }
}
