using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;
//using UnityEngine.WSA;
using UnityEngine.SceneManagement;

public class BossBattleStartUp : StartUp
{
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
            if (GameObject.Find("MC").GetComponent<MCStats>().b == -1)
            E = Instantiate(enemyP[0]);
            else if (GameObject.Find("MC").GetComponent<MCStats>().dd == -1)
            E = Instantiate(enemyP[1]);
            E.GetComponent<CharStats>().position = 2;
            E.GetComponent<Transform>().position = enemyPos[E.GetComponent<CharStats>().position].transform.position;

        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log(players.Length);
            players[i].GetComponent<SpriteRenderer>().enabled = true;
            if (players[i].GetComponent<KrysStats>() != null)
            {
                players[i].GetComponent<KrysStats>().ChangeForm(1);
                players[i].GetComponent<KrysStats>().anim.SetInteger("Phase", 1);
            }
            else if (players[i].GetComponent<MCStats>() != null)
            {
                players[i].GetComponent<MCStats>().WeaponSwap();
                players[i].GetComponent<SpriteRenderer>().flipX = true;
                players[i].GetComponent<Rigidbody>().isKinematic = true;

            }
            Holder = Instantiate(manabar, GameObject.FindGameObjectWithTag("HP").transform);
            Holder.GetComponent<ManaBarS>().p = players[2 - i];
            Holder = Instantiate(healthbar, GameObject.FindGameObjectWithTag("HP").transform);
            Holder.GetComponent<HealthBarS>().p = players[2 - i];
            players[i].GetComponent<Transform>().position = playerPos[players[i].GetComponent<CharStats>().position].transform.position;
        }
        Order();
        GameObject.Find("MC").GetComponent<PlayerStats>().ChangeForm(1);
        GameObject.FindGameObjectsWithTag("Enemy")[0].GetComponent<CharStats>().isTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (order == inOrder.Length)
        {
            ReSort();
            order = 0;
        }
        int d = 0;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<CharStats>().HP <= 0)
            {
                d++;
            }
            if (d == players.Length)
            {
                SceneManager.LoadScene("Game Over");
            }
        }
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
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
                    if (GameObject.Find("MC").GetComponent<MCStats>().b == -1)
                        GameObject.Find("MC").GetComponent<MCStats>().b = 1;
                    else if (GameObject.Find("MC").GetComponent<MCStats>().dd == -1)
                        GameObject.Find("MC").GetComponent<MCStats>().dd = 1;
                }
            }
            j = 1;
            End.SetActive(true);
            Turns.SetActive(false);
            for (int i = 0; i < Actions.Length; i++)
                Actions[i].SetActive(false);
        }
    }
}
