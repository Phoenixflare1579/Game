using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarS : MonoBehaviour
{
    public Slider s;
    Image f;
    public GameObject p;

    void Start()
    {
        s = GetComponent<Slider>();
        f = gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>();
        if (p.GetComponent<KrysStats>() != null)
        {
            s.maxValue = p.GetComponent<KrysStats>().MaxMana;
        }
        else if (p.GetComponent<MCStats>() != null)
        {
            s.maxValue = p.GetComponent<MCStats>().MaxMana;
        }
        s.value = s.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (p.GetComponent<KrysStats>() != null)
        {
            s.value = p.GetComponent<KrysStats>().Mana;
        }
        else if (p.GetComponent<MCStats>() != null)
        {
            s.value = p.GetComponent<MCStats>().Mana;
        }
    }
}
