using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class SaveManager : MonoBehaviour
{
    public TMP_InputField saveName;
    public GameObject loadbuttonP;

    public void OnSave()
    {

    }

    public string[] savefiles;
    public void GetLoadFiles()
    {
        if(!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        //savefiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");
    }
}
