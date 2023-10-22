using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesS : MonoBehaviour
{
    public GameObject Form1;
    public GameObject Form2;
    public GameObject Form3;
    public GameObject Krys;

    private void Start()
    {
        Krys = GameObject.Find("Krys");
    }

    public void Ability()
    {
       if (Krys.GetComponent<KrysStats>().Form == 1)
        {
            Form1.SetActive(true);
        }
       else if (Krys.GetComponent<KrysStats>().Form == 2)
        {
            Form2.SetActive(true);
        }
       else if (Krys.GetComponent<KrysStats>().Form == 3)
        {
            Form3.SetActive(true);
        }
    }
}
