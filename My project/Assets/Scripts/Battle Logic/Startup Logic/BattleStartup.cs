using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class BattleStartup : StartUp
    
{
    void Start()
    {
        players =GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                E = Instantiate(enemyP[Random.Range(0, enemyP.Length)]);
                E.GetComponent<CharStats>().position = i;
                E.GetComponent<Transform>().position = enemyPos[E.GetComponent<CharStats>().position].transform.position;
            }
        }
        else
        {
            for (int i = 0; i < Random.Range(1, 2); i++)
            {
                E = Instantiate(enemyP[Random.Range(0, enemyP.Length)]);
                E.GetComponent<CharStats>().position = i;
                E.GetComponent<Transform>().position = enemyPos[E.GetComponent<CharStats>().position].transform.position;
            }
        }

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<SpriteRenderer>().enabled = true;
            if (players[i].GetComponent<KrysStats>()!=null) 
            {
                players[i].GetComponent<KrysStats>().ChangeForm(1);
                players[i].GetComponent<KrysStats>().anim.SetInteger("Phase", 1);
            }
            else if (players[i].GetComponent<MCStats>() != null)
            {
                players[i].GetComponent<MCStats>().WeaponSwap();
                players[i].GetComponent<SpriteRenderer>().flipX = true;
                players[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            Holder = Instantiate(manabar, GameObject.FindGameObjectWithTag("HP").transform);
            Holder.GetComponent<ManaBarS>().p = players[i];
            Holder = Instantiate(healthbar, GameObject.FindGameObjectWithTag("HP").transform);
            Holder.GetComponent<HealthBarS>().p = players[i];
            players[i].GetComponent<Transform>().position = playerPos[players[i].GetComponent<CharStats>().position].transform.position;
        }
        Order();
        GameObject.FindGameObjectsWithTag("Enemy")[0].GetComponent<CharStats>().isTarget = true;
    }
    private void Update()
    {
        if (order==inOrder.Length)
        {
            ReSort();
            order = 0;
        }
        int d = 0;
        for (int i=0; i<players.Length; i++)
        {
            if(players[i].GetComponent<CharStats>().HP<=0)
            {
                d++;
            }
            if(d==players.Length)
            {
                SceneManager.LoadScene("Game Over");
            }
        }
        if(GameObject.FindGameObjectWithTag("Enemy")!=null)
        {
            End.SetActive(false);
        }
        else
        {
            if (j == 0)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].GetComponent<CharStats>().EXP += xp;
                }
            }
            j = 1;
            End.SetActive(true);
            Turns.SetActive(false);
            for (int i = 0;i < Actions.Length; i++)
                Actions[i].SetActive(false);
        }
    }
}
