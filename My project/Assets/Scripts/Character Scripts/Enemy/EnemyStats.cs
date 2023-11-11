using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharStats
{
    // Start is called before the first frame update
    public string[] weakness;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetTarget()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[UnityEngine.Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length - 1)];
    }
    public void SetWeakness(string[] weakness)
    {
        for (int i = 0; i < weakness.Length; i++) 
        {
            weaknesses.Add(weakness[i], true);
        }
    }
}
