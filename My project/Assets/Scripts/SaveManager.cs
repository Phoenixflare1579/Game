using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class SaveManager : MonoBehaviour,IInteractable
{
    CharStats MC;
    CharStats Krys;
    private void Update()
    {
        if (GameObject.Find("MC").GetComponent<CharStats>()!=null)
        MC = GameObject.Find("MC").GetComponent<CharStats>();
        if (GameObject.Find("Krys").GetComponent<CharStats>()!=null)
        Krys = GameObject.Find("Krys").GetComponent<CharStats>();
    }

    public void Save()
    {
        SaveS.SaveData(MC,Krys);
    }

    public void Load()
    {
        Data data = SaveS.LoadData();
        MC.Level = data.levelM;
        MC.EXP = data.expM;
        MC.skillpoints = data.skillpointsM;
        MC.HP = data.healthM;
        MC.Mana = data.manaM;
        MC.CharName = data.nameM;
        MC.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        Krys.Level = data.levelK;
        Krys.EXP = data.expK;
        Krys.skillpoints = data.skillpointsK;
        Krys.HP = data.healthK;
        Krys.Mana = data.manaK;
    }

    public void Interact()
    {
        Save();
    }
}
