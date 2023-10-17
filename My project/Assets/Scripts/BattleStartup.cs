using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BattleStartup : MonoBehaviour
    
{
    public GameObject[] playerP;
    public GameObject[] enemyP;
    public string[] Turn;
    public string[][] inOrder;
    public int order = 0;
    GameObject Holder;
    public GameObject healthbar;
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

        Turn = new string[GameObject.FindGameObjectsWithTag("Player").Length-1+ GameObject.FindGameObjectsWithTag("Enemy").Length];

        inOrder = new string[GameObject.FindGameObjectsWithTag("Player").Length - 1 + GameObject.FindGameObjectsWithTag("Enemy").Length][];

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            Turn[i] = (GameObject.FindGameObjectsWithTag("Player")[i].name);
        }
            
        for(int i = GameObject.FindGameObjectsWithTag("Player").Length; i < GameObject.FindGameObjectsWithTag("Enemy").Length+GameObject.FindGameObjectsWithTag("Player").Length-1; i++)
        {
            Turn[i] = (GameObject.FindGameObjectsWithTag("Enemy")[i].name);
        }

        for (int i = 0; i< Turn.Length; i++)//Speed Random Bais
        {
            int CharSpeed = (GameObject.Find(Turn[i]).GetComponent<CharStats>().Speed + Random.Range(0, 100));

            inOrder[i] = new string[] { Turn[i], CharSpeed.ToString() };

        }

        var sorted = inOrder.OrderByDescending(y => y[1]);

        foreach (string[] inOrder in sorted) 
        {
            Debug.Log(inOrder[0]);
            Debug.Log(inOrder[1]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            Holder = Instantiate(healthbar, GameObject.FindGameObjectWithTag("HP").transform);
            Holder.GetComponent<HealthBarS>().p = GameObject.FindGameObjectsWithTag("Player")[i];
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
