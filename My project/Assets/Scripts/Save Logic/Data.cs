using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Data 
{
    public Dictionary<string, int> Items = new Dictionary<string, int>();
    public int levelM;
    public int expM;
    public int[] M;
    public bool[] skillsM1;
    public bool[] skillsM2;
    public bool[] skillsM3;
    public int bear;
    public int demondeer;
    public int skillpointsM;
    public int healthM;
    public int manaM;
    public string nameM;
    public float[] position;
    public int posM;
    public int levelK;
    public int expK;
    public int[] statK;
    public int skillpointsK;
    public int healthK;
    public int manaK;
    public bool[] skillsK1;
    public bool[] skillsK2;
    public bool[] skillsK3;
    public int posK;
    public int levelJ;
    public int expJ;
    public int[] statJ;
    public int skillpointsJ;
    public int healthJ;
    public int manaJ;
    public bool[] skillsJ1;
    public bool[] skillsJ2;
    public bool[] skillsJ3;
    public int posJ;
    public string scene;
    public bool T;

    public Data(MCStats statsMC, PlayerStats statsK, PlayerStats statsJ) 
    {
        //MC Save
        levelM = statsMC.Level;
        expM = statsMC.EXP;
        skillsM1 = statsMC.skilltree1;
        skillsM2 = statsMC.skilltree2;
        skillsM3 = statsMC.skilltree3;
        skillpointsM = statsMC.skillpoints;
        healthM = statsMC.HP;
        manaM = statsMC.Mana;
        nameM = statsMC.CharName;
        posM = statsMC.position;
        bear = statsMC.b;
        demondeer = statsMC.dd;
        position = new float[3];
        Debug.Log(statsMC.Location);
        position[0] = statsMC.Location.x;
        position[1] = statsMC.Location.y;
        position[2] = statsMC.Location.z;
        //Krys Save
        levelK = statsK.Level;
        expK = statsK.EXP;
        skillpointsK = statsK.skillpoints;
        healthK = statsK.HP;
        manaK = statsK.Mana;
        skillsK1 = statsK.skilltree1;
        skillsK2 = statsK.skilltree2;
        skillsK3 = statsK.skilltree3;
        posK = statsK.position;
        //Johanna Save
        levelJ = statsJ.Level;
        expJ = statsJ.EXP;
        skillpointsJ = statsJ.skillpoints;
        healthJ = statsJ.HP;
        manaJ = statsJ.Mana;
        skillsJ1 = statsJ.skilltree1;
        skillsJ2 = statsJ.skilltree2;
        skillsJ3 = statsJ.skilltree3;
        posJ = statsJ.position;
        //World Save
        Debug.Log(SceneManager.GetActiveScene().name);
        scene = SceneManager.GetActiveScene().name;
        int[] Mstat = { statsMC.MaxHP, statsMC.MaxMana, statsMC.Speed, statsMC.Def, statsMC.PhysAtk, statsMC.MagicAtk, statsMC.MagicDef, statsMC.Evasion, statsMC.Accuracy, statsMC.Crit, statsMC.CritDmg };
        M = Mstat;

        int[] Kstat = { statsK.MaxHP, statsK.MaxMana, statsK.Speed, statsK.Def, statsK.PhysAtk, statsK.MagicAtk, statsK.MagicDef, statsK.Evasion, statsK.Accuracy, statsK.Crit, statsK.CritDmg};
        statK = Kstat;

        int[] Jstat = { statsJ.MaxHP, statsJ.MaxMana, statsJ.Speed, statsJ.Def, statsJ.PhysAtk, statsJ.MagicAtk, statsJ.MagicDef, statsJ.Evasion, statsJ.Accuracy, statsJ.Crit, statsJ.CritDmg };
        statJ = Jstat;

        Items = statsMC.Consumables;
    }
}
