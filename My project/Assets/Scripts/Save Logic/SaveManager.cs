using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class SaveManager : MonoBehaviour
{
    public MCStats MC;
    public PlayerStats Krys;
    public PlayerStats Johanna;
    private void Update()
    {
        if (MC == null)
        MC = GameObject.Find("MC").GetComponent<MCStats>();
        if (Krys == null)
        Krys = GameObject.Find("Krys").GetComponent<PlayerStats>();
        if (Johanna == null)
        Johanna = GameObject.Find("Johanna").GetComponent<PlayerStats>();
    }

    public void Save()
    {
        SaveS.SaveData(MC,Krys,Johanna);
    }

    public void Load()
    {
        Data data = SaveS.LoadData();
        SceneManager.LoadScene(data.scene);
        MC.Level = data.levelM;
        MC.EXP = data.expM;
        MC.MaxHP = data.M[0];
        MC.MaxMana = data.M[1];
        MC.Speed = data.M[2];
        MC.Def = data.M[3];
        MC.PhysAtk = data.M[4];
        MC.MagicAtk = data.M[5];
        MC.MagicDef = data.M[6];
        MC.Evasion = data.M[7];
        MC.Accuracy = data.M[8];
        MC.Crit = data.M[9];
        MC.CritDmg = data.M[10];
        MC.skillpoints = data.skillpointsM;
        MC.skilltree1 = data.skillsM1;
        MC.skilltree2 = data.skillsM2;
        MC.skilltree3 = data.skillsM3;
        MC.position = data.posM;
        MC.dd = data.demondeer;
        MC.b = data.bear;
        MC.HP = data.healthM;
        MC.Mana = data.manaM;
        MC.CharName = data.nameM;
        MC.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        Krys.Level = data.levelK;
        Krys.EXP = data.expK;
        Krys.MaxHP = data.statK[0];
        Krys.MaxMana = data.statK[1];
        Krys.Speed = data.statK[2];
        Krys.Def = data.statK[3];
        Krys.PhysAtk = data.statK[4];
        Krys.MagicAtk = data.statK[5];
        Krys.MagicDef = data.statK[6];
        Krys.Evasion = data.statK[7];
        Krys.Accuracy = data.statK[8];
        Krys.Crit = data.statK[9];
        Krys.CritDmg = data.statK[10];
        Krys.skillpoints = data.skillpointsK;
        Krys.skilltree1 = data.skillsK1;
        Krys.skilltree2 = data.skillsK2;
        Krys.skilltree3 = data.skillsK3;
        Krys.position = data.posK;
        Krys.HP = data.healthK;
        Krys.Mana = data.manaK;
        Johanna.Level = data.levelJ;
        Johanna.EXP = data.expJ;
        Johanna.MaxHP = data.statJ[0];
        Johanna.MaxMana = data.statJ[1];
        Johanna.Speed = data.statJ[2];
        Johanna.Def = data.statJ[3];
        Johanna.PhysAtk = data.statJ[4];
        Johanna.MagicAtk = data.statJ[5];
        Johanna.MagicDef = data.statJ[6];
        Johanna.Evasion = data.statJ[7];
        Johanna.Accuracy = data.statJ[8];
        Johanna.Crit = data.statJ[9];
        Johanna.CritDmg = data.statJ[10];
        Johanna.skillpoints = data.skillpointsJ;
        Johanna.skilltree1 = data.skillsJ1;
        Johanna.skilltree2 = data.skillsJ2;
        Johanna.skilltree3 = data.skillsJ3;
        Johanna.position = data.posJ;
        Johanna.HP = data.healthJ;
        Johanna.Mana = data.manaJ;
    }
}
