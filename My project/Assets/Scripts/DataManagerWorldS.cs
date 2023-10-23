using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagerWorldS : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MC;
    void Start()
    {
        MC = GameObject.Find("MC");
        MC.GetComponent<Battle>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
