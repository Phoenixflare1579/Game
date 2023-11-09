using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCData 
{
    public int level;
    public int exp;
    public bool[] skills;
    public int skillpoints;
    public int health;
    public int mana;
    public float[] position;

    public MCData(MCStats stats) 
    {
        level = stats.Level;
        exp = stats.EXP;
        skillpoints = stats.skillpoints;
        health = stats.HP;
        mana = stats.Mana;
        position = new float[3];
        position[0] = stats.transform.position.x;
        position[1] = stats.transform.position.y;
        position[2] = stats.transform.position.z;
    }
}
