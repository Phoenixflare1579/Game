using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartup : MonoBehaviour
    
{
    public GameObject[] playerP;
    public GameObject[] enemyP;
    GameObject[] player;
    int pos = 0;
    Vector3 playertrans;
    
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
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        for(int i=0; i<player.Length; i++)
        {
            pos=player[i].GetComponent<CharStats>().position;
            if (pos == 1)
            {
                playertrans=player[i].GetComponent<Transform>().position;
                playertrans.x = 2.4f;
                playertrans.y = 3.75f;
                playertrans.z = 0.07f;
            }
            else if (pos == 2)
            {
                playertrans = player[i].GetComponent<Transform>().position;
                playertrans.x = 2.4f;
                playertrans.y = 3.75f;
                playertrans.z = 0.07f;
            }
        }
    }
}
