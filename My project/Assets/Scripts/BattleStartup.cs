using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartup : MonoBehaviour
    
{
    public GameObject[] playerP;
    public GameObject[] enemyP;
    public string[] Turn;
    public int order = 0;
    public int[] randomizer;
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
        {
            Turn[i] = (GameObject.FindGameObjectsWithTag("Player")[i].name);
            if (GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<KrysStats>() != null)
                randomizer[i] = GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<KrysStats>().Speed + Random.Range(0, 100);
            else if (GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<MCStats>() != null)
                randomizer[i] = GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<MCStats>().Speed + Random.Range(0, 100);
        }
        for (int i = GameObject.FindGameObjectsWithTag("Player").Length; i < GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Player").Length - 1; i++)
        {
            Turn[i] = (GameObject.FindGameObjectsWithTag("Enemy")[i].name);
            randomizer[i] = GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<EnemyStats>().Speed + Random.Range(0, 100);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Player").Length - 1; i++)
        {
            //I got the speed saved but we have to organize the array in greatest to least and then order the turn array in that same order.
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
