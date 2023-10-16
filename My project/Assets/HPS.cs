using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPS : MonoBehaviour
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
        gameObject.GetComponent<TextMeshProUGUI>().text = parent.GetComponent<HealthBarS>().s.value + "/" + parent.GetComponent<HealthBarS>().s.maxValue;
    }
}
