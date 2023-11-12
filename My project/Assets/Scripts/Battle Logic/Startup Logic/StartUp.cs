using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public GameObject[] enemyP;
    public GameObject[] players;
    public GameObject[] playerPos;
    public GameObject[] enemyPos;
    public string[] inOrder;
    public int[] Speeds;
    public int order = 0;
    public GameObject Holder;
    public GameObject E;
    public GameObject healthbar;
    public GameObject manabar;
    public GameObject End;
    public GameObject Turns;
    public GameObject[] Actions;
    public int xp = 0;
    public int j = 0;
    public void ReSort()
    {
        for (int i = 0; i < inOrder.Length; i++)
        {
            int CharSpeed = GameObject.Find(inOrder[i]).GetComponent<CharStats>().Speed + Random.Range(0, 100);
            Speeds[i] = CharSpeed;
        }
        System.Array.Sort(Speeds, inOrder);
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
    public void Increase()
    {
        StartCoroutine(wait());
        order++;
    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(10);
    }
}
