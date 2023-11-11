using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("MC");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(10, 0, -400);
    }
}