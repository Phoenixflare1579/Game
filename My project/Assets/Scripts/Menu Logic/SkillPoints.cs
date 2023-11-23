using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillPoints : MonoBehaviour
{
    public string C;
    PlayerStats Char;
    void Start()
    {
        Char = GameObject.Find(C).GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Skill \nPoints: " + Char.skillpoints;
    }
}
