using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public CharStats MC;
    public CharStats Krys;
    private void Update()
    {
        if (MC == null)
        MC = GameObject.Find("MC").GetComponent<CharStats>();
        if (Krys == null)
        Krys = GameObject.Find("Krys").GetComponent<CharStats>();
    }

    public void Save()
    {
        SaveS.SaveData(MC,Krys);
    }

    public void Load()
    {
        Data data = SaveS.LoadData();
        SceneManager.LoadScene(data.scene);
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
}
