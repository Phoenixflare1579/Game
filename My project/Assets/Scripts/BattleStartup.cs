using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class BattleStartup : MonoBehaviour
    
{
    public GameObject[] enemyP;
    GameObject[] players;
    public GameObject[] playerPos;
    public GameObject[] enemyPos;
    public string[] inOrder;
    public int[] Speeds;
    public int order = 0;
    GameObject Holder;
    GameObject E;
    public GameObject healthbar;
    public GameObject manabar;
    public GameObject End;
    public GameObject Turns;
    public GameObject[] Actions;
    public int xp=0;
    int j = 0;
    public void ReSort()
    {
        for (int i = 0; i < inOrder.Length; i++)
        {
            int CharSpeed = GameObject.Find(inOrder[i]).GetComponent<CharStats>().Speed + Random.Range(0, 100);
            Speeds[i] = CharSpeed;
        }
        System.Array.Sort(Speeds,inOrder);
        System.Array.Reverse(inOrder);
        for (int i = 0; i < Speeds.Length; i++)
        Debug.Log(Speeds[i]);
    }
    public void Order()
    {
        inOrder = new string[players.Length + GameObject.FindGameObjectsWithTag("Enemy").Length];

        Speeds = new int[players.Length + GameObject.FindGameObjectsWithTag("Enemy").Length];

        for (int i = 0; i < players.Length; i++)
        {
            inOrder[i] = (players[i].name);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            inOrder[i + players.Length] = GameObject.FindGameObjectsWithTag("Enemy")[i].name;
        }

        ReSort();
    }
    void Start()
    {
        players =GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < Random.Range(1,4); i++)
        {
            E=Instantiate(enemyP[Random.Range(0,enemyP.Length)]);
            E.GetComponent<CharStats>().position=i;
            E.GetComponent<Transform>().position = enemyPos[E.GetComponent<CharStats>().position].transform.position;
        }

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<SpriteRenderer>().enabled = true;
            if (players[i].GetComponent<KrysStats>()!=null) 
            {
                players[i].GetComponent<KrysStats>().Martial();
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
    public void Increase()
    {
        order++;
    }
}
