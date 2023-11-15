using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MC;
    public GameObject Krys;
    public GameObject Johanna;
    public GameObject Cam;
    public GameObject Battle;
    public GameObject Pause;

    private void Start()
    {
        for (int i = 0;i< GameObject.FindGameObjectsWithTag("Player").Length;i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Player")[i]);
        }
        
    }

    public void Play()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene("Starting Level");
        GameObject rename = Instantiate(MC);
        rename.name = rename.name.Replace("(Clone)", "").Trim();
        rename = Instantiate(Krys);
        rename.name = rename.name.Replace("(Clone)", "").Trim();
        rename = Instantiate(Cam);
        rename.name = rename.name.Replace("(Clone)", "").Trim();
        rename = Instantiate(Battle);
        rename.name = rename.name.Replace("(Clone)", "").Trim();
        rename = Instantiate(Pause);
        rename.name = rename.name.Replace("(Clone)", "").Trim();
    }

    public void Exit()
    {
        Application.Quit();
    }
    private void Update()
    {

    }
}
