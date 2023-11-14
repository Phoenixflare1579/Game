using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Data 
{
    public int levelM;
    public int expM;
    public bool[] skillsM;
    public int skillpointsM;
    public int healthM;
    public int manaM;
    public string nameM;
    public float[] position;
    public int levelK;
    public int expK;
    public bool[] skillsK;
    public int skillpointsK;
    public int healthK;
    public int manaK;
    public string scene;
    public bool T;

    public Data(CharStats statsMC, CharStats statsK) 
    {
        //MC Save
        levelM = statsMC.Level;
        expM = statsMC.EXP;
        skillpointsM = statsMC.skillpoints;
        healthM = statsMC.HP;
        manaM = statsMC.Mana;
        nameM = statsMC.CharName;
        position = new float[3];
        position[0] = statsMC.transform.position.x;
        position[1] = statsMC.transform.position.y;
        position[2] = statsMC.transform.position.z;
        //Krys Save
        levelK = statsK.Level;
        expK = statsK.EXP;
        skillpointsK = statsK.skillpoints;
        healthK = statsK.HP;
        manaK = statsK.Mana;
        //World Save
        scene = SceneManager.GetActiveScene().name;
    }
}
