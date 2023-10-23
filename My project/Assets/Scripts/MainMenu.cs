using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MC;
    public GameObject Krys;

    private void Start()
    {
        for (int i = 0;i< GameObject.FindGameObjectsWithTag("Player").Length;i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Player")[i]);
        }
        
    }

    public void Play()
    {
        SceneManager.LoadScene("World");
        GameObject rename = Instantiate(MC);
        rename.name = rename.name.Replace("(Clone)", "").Trim();
        rename = Instantiate(Krys);
        rename.name = rename.name.Replace("(Clone)", "").Trim();

    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    private void Update()
    {

    }
}
