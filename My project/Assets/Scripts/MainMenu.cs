using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MC;
    public GameObject Krys;
    int t=0;
    int t2 = 0;
    public void Play()
    {
        t++;
        //Instantiate(MC);
        //Instantiate(Krys);
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length>0 && t==0)
        {
            for (int i = 0;i< GameObject.FindGameObjectsWithTag("Player").Length;i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Player")[i]);
            }
        }
        if (t==1)
        {
            t2++;
            if (t2>250)
            SceneManager.LoadScene("World");
        }
    }
}
