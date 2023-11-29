using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChests : MonoBehaviour
{
    public bool[] chests;

    void Start()
    {
        chests = new bool[10];
        for (int i = 0; i < chests.Length; i++) 
        {
            chests[i] = false;
        }
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Chest") != null)
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Chest").Length; i++)
        {
            if (chests[i]==true && GameObject.FindGameObjectsWithTag("Chest")[i].GetComponent<Chest>().i == false)
                {
                    GameObject.FindGameObjectsWithTag("Chest")[i].GetComponent<Chest>().i = true;
                }
            chests[i] = GameObject.FindGameObjectsWithTag("Chest")[i].GetComponent<Chest>().i;
        }

    }
}
