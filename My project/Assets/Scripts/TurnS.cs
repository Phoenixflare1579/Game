using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnS : MonoBehaviour
{
    public GameObject logic;

    void Update()
    {
        if (logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order] != "MC Base")
            this.GetComponent<TextMeshProUGUI>().text = logic.GetComponent<BattleStartup>().inOrder[logic.GetComponent<BattleStartup>().order];
        else
            this.GetComponent<TextMeshProUGUI>().text = "???";
    }
}
