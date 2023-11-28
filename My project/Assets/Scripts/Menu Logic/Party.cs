using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    GameObject Char;
    public string C;
    public int position=-1;
    // Start is called before the first frame update
    void Start()
    {
        Char = GameObject.Find(C);
    }

    // Update is called once per frame
    void Update()
    {
        if (position != -1 && position < 4)
        {
            Char.SetActive(true);
            Char.GetComponent<CharStats>().position = position;
        }
        else if (position != -1 && position > 4)
        {
            if (Char.name != "MC")
            {
                Char.SetActive(false);
                Char.GetComponent<CharStats>().position = 3;
            }
        }
    }
    public void SetPosition(int value)
    {
        position = value;
    }
}
