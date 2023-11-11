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
        gameObject.GetComponent<TextMeshProUGUI>().text = parent.GetComponent<CharStats>().CharName;
    }
}
