using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class XPS : MonoBehaviour
{
    public GameObject logic;
    public GameObject MC;
    public GameObject Krys;

    private void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text= "EXP Gained for the party: " + logic.GetComponent<BattleStartup>().xp + '\n' + MC.name + ": " + MC.GetComponent<CharStats>().EXP + "/" + MC.GetComponent<CharStats>().EXPMax + "\n" + Krys.name + ": " + Krys.GetComponent<CharStats>().EXP + "/" + Krys.GetComponent<CharStats>().EXPMax;
    }
    private void Start()
    {
        MC = GameObject.Find("MC");
        Krys = GameObject.Find("Krys");
    }
}
