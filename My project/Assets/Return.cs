using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public GameObject MC;
    private void Start()
    {
        MC = GameObject.Find("MC");
    }
    public void R()
    {
        SceneManager.LoadScene("World");
        MC.gameObject.transform.position = MC.GetComponent<MCStats>().Location;
    }
}
