using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    GameObject B;
    private void Start()
    {
        B = GameObject.FindGameObjectWithTag("Counter");
    }
    private void Update()
    {
        if (B == null) 
        {
            B = GameObject.FindGameObjectWithTag("Counter");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        B.GetComponent<Battle>().Safe();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            B.GetComponent<Battle>().UnSafe();
    }
}
