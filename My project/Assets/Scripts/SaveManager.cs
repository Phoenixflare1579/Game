using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class SaveManager : MonoBehaviour
{
    public void Save()
    {
        SaveS.SaveData(GameObject.Find("MC").GetComponent<CharStats>(), GameObject.Find("Krys").GetComponent<CharStats>());
    }
}
