using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharStats
{
    // Start is called before the first frame update
    public string[] weakness;
    public int[] min;
    public int[] max;
    public int[] growth;
    public Consumable[] items;


    public void GetTarget()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[(int)Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length)];
    }
    public void SetWeakness(string[] weakness)
    {
        for (int i = 0; i < weakness.Length; i++) 
        {
            weaknesses.Add(weakness[i], true);
        }
    }
    public void StatRandom(int[] min, int[] max, int[] growth)
    {
        Level = Random.Range(min[0], max[0]);
        MaxHP = Random.Range(min[1], max[1]) + (growth[0] * Level);
        HP = MaxHP;
        Speed = Random.Range(min[2], max[2]) + (growth[1] * Level);
        Def = Random.Range(min[3], max[3]) + (growth[2] * Level);
        PhysAtk = Random.Range(min[4], max[4]) + (growth[3] * Level);
        MagicAtk = Random.Range(min[5], max[5]) + (growth[4] * Level);
        MagicDef = Random.Range(min[6], max[6]) + (growth[5] * Level);
        Evasion = Random.Range(min[7], max[7]) + (growth[6] * Level);
        Accuracy = Random.Range(min[8], max[8] ) + (growth[7] * Level);
    }
    public void GetAttacks(string attacks) 
    {

    }
    public void GetConsumables(Consumable[] consumables) 
    {
    
    }
}
