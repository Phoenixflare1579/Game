using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartup : MonoBehaviour
    
{
    public GameObject[] playerP;
    public GameObject[] enemyP;
    public string[] Turn;
    public int order = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            for (int i = 0; i < playerP.Length; i++)
            {
                Instantiate(playerP[i]);
            }
        }

        for (int i = 0; i < enemyP.Length; i++)
        {
            Instantiate(enemyP[i]);
        }
        Turn = new string[GameObject.FindGameObjectsWithTag("Player").Length+ GameObject.FindGameObjectsWithTag("Enemy").Length];
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
            Turn[i]=(GameObject.FindGameObjectsWithTag("Player")[i].name);
        for(int i = GameObject.FindGameObjectsWithTag("Player").Length; i < GameObject.FindGameObjectsWithTag("Enemy").Length+GameObject.FindGameObjectsWithTag("Player").Length-1; i++)
            Turn[i]=(GameObject.FindGameObjectsWithTag("Enemy")[i].name);
        // for (int i = 0; i<Turn.Length; i++)//Victor do you know how to randomize the turn order array and have a bias based on speed?
        {
            //int Randomize=Random.Range(0,Turn.Length);
            //Turn[i]=
        }
    }
    private void Update()
    {
        if(order==Turn.Length)
        {
            order = 0;
        }
    }
}
