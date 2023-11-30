using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Data 
{
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
        M[0] = statsMC.MaxHP;
        M[1] = statsMC.MaxMana;
        M[2] = statsMC.Speed;
        M[3] = statsMC.Def;
        M[4] = statsMC.PhysAtk;
        M[5] = statsMC.MagicAtk;
        M[6] = statsMC.MagicDef;
        M[7] = statsMC.Evasion;
        M[8] = statsMC.Accuracy;
        M[9] = statsMC.Crit;
        M[10] = statsMC.CritDmg;
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
        position[0] = statsMC.transform.position.x;
        position[1] = statsMC.transform.position.y;
        position[2] = statsMC.transform.position.z;
        //Krys Save
        levelK = statsK.Level;
        expK = statsK.EXP;
        statK[0] = statsK.MaxHP;
        statK[1] = statsK.MaxMana;
        statK[2] = statsK.Speed;
        statK[3] = statsK.Def;
        statK[4] = statsK.PhysAtk;
        statK[5] = statsK.MagicAtk;
        statK[6] = statsK.MagicDef;
        statK[7] = statsK.Evasion;
        statK[8] = statsK.Accuracy;
        statK[9] = statsK.Crit;
        statK[10] = statsK.CritDmg;
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
        statJ[0] = statsJ.MaxHP;
        statJ[1] = statsJ.MaxMana;
        statJ[2] = statsJ.Speed;
        statJ[3] = statsJ.Def;
        statJ[4] = statsJ.PhysAtk;
        statJ[5] = statsJ.MagicAtk;
        statJ[6] = statsJ.MagicDef;
        statJ[7] = statsJ.Evasion;
        statJ[8] = statsJ.Accuracy;
        statJ[9] = statsJ.Crit;
        statJ[10] = statsJ.CritDmg;
        skillpointsJ = statsJ.skillpoints;
        healthJ = statsJ.HP;
        manaJ = statsJ.Mana;
        skillsJ1 = statsJ.skilltree1;
        skillsJ2 = statsJ.skilltree2;
        skillsJ3 = statsJ.skilltree3;
        posJ = statsJ.position;
        //World Save
        scene = SceneManager.GetActiveScene().name;
    }
}
