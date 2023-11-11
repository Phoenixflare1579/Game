using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarS : MonoBehaviour
{
    public Slider s;
    Image f;
    public GameObject p;

    void Start()
    {
        s= GetComponent<Slider>();
        f= gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>();
        if (p.GetComponent<CharStats>() != null)
        {
            s.maxValue = p.GetComponent<CharStats>().MaxHP;
        }
        s.value = s.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (p.GetComponent<CharStats>() != null)
        {
            s.value = p.GetComponent<CharStats>().HP;
        }
        if (s.value >= s.maxValue/2)
        {
            f.color = new Color32(0,255,0,255);
        }
        else if (s.value < s.maxValue / 2 && s.value >= s.maxValue/4)
        {
            f.color = new Color32(255, 255, 0, 255);
        }
        else if (s.value < s.maxValue / 4 && s.value>0)
        {
            f.color = new Color32(255, 0, 0, 255);
        }
        else if (s.value <=0)
        {
            f.color = new Color32(0, 0, 0, 0);
        }
    }
}
