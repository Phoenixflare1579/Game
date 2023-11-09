using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public GameObject MC;
    public GameObject Krys;
    private void Start()
    {
        MC = GameObject.Find("MC");
        Krys = GameObject.Find("Krys");
    }
    public void R()
    {
        SceneManager.LoadScene("World");
        MC.gameObject.transform.position = MC.GetComponent<MCStats>().Location;
        MC.GetComponent<PlayerInput>().ActivateInput();
        MC.GetComponent<Rigidbody>().useGravity = true;
        Krys.GetComponent<SpriteRenderer>().enabled = false;
    }
}
