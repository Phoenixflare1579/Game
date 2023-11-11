using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaS : MonoBehaviour
{
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = parent.GetComponent<ManaBarS>().s.value + "/" + parent.GetComponent<ManaBarS>().s.maxValue;
    }
}
