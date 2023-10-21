using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BattleStartup : MonoBehaviour
    
{
    public GameObject[] enemyP;
    public GameObject[] players;
    public GameObject[] playerPos;
    public GameObject[] enemyPos;
    int p=-1;
    public string[] Turn;
    public string[][] inOrder;
    public int order = 0;
    GameObject Holder;
    GameObject E;
    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {
        players=GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < enemyP.Length; i++)
        {
            E=Instantiate(enemyP[i]);
            if (p == E.GetComponent<CharStats>().position)
                E.GetComponent<CharStats>().position++;
            E.GetComponent<Transform>().position = enemyPos[E.GetComponent<CharStats>().position].transform.position;
            p = E.GetComponent<CharStats>().position;
        }

        Turn = new string[players.Length-1+ GameObject.FindGameObjectsWithTag("Enemy").Length];

        inOrder = new string[players.Length - 1 + GameObject.FindGameObjectsWithTag("Enemy").Length][];

        for (int i = 0; i < players.Length; i++)
        {
            Turn[i] = (players[i].name);
        }
            
        for(int i = players.Length; i < GameObject.FindGameObjectsWithTag("Enemy").Length+players.Length-1; i++)
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

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<SpriteRenderer>().enabled = true;
            if (players[i].GetComponent<KrysStats>()!=null) 
            {
                players[i].GetComponent<KrysStats>().Martial();
            }
            else if (players[i].GetComponent<MCStats>() != null)
            {
                players[i].GetComponent<MCStats>().WeaponSwap();
                players[i].GetComponent<SpriteRenderer>().flipX = true;
            }
            Holder = Instantiate(healthbar, GameObject.FindGameObjectWithTag("HP").transform);
            Holder.GetComponent<HealthBarS>().p = players[i];
            players[i].GetComponent<Transform>().position = playerPos[players[i].GetComponent<CharStats>().position].transform.position;
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
