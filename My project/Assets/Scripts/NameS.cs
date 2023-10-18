using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameS : MonoBehaviour
{
    GameObject parent;
    void Start()
    {
        parent = gameObject.transform.parent.gameObject.GetComponent<HealthBarS>().p;
        if (parent.GetComponent<KrysStats>()!=null)
        gameObject.GetComponent<TextMeshProUGUI>().text = parent.GetComponent<KrysStats>().CharName;
        else if (parent.GetComponent<MCStats>()!= null)
        gameObject.GetComponent<TextMeshProUGUI>().text = parent.GetComponent<MCStats>().CharName;
    }
}
