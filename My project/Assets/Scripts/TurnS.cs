using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnS : MonoBehaviour
{
    public GameObject logic;

    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = GameObject.Find(logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order]).GetComponent<CharStats>().CharName;
    }
}
