using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EnterBossFight : MonoBehaviour
{
    GameObject MC;
    public string boss;
    public GameObject bossTrigger;
    private void Start()
    {
        MC = GameObject.Find("MC");
        if (boss == "b" && MC.GetComponent<MCStats>().b != 1)
        {
            bossTrigger.SetActive(true);
        }
        if (boss == "dd" && MC.GetComponent<MCStats>().dd != 1)
        {
            bossTrigger.SetActive(true);
        }
    }
    private void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        MC.GetComponent<MCStats>().Location = MC.gameObject.transform.position;
        
        MC.GetComponent<MCStats>().scene = SceneManager.GetActiveScene().name;
        MC.GetComponent<Animator>().SetInteger("Weapon", 1);
        MC.GetComponent<Rigidbody>().useGravity = false;
        MC.GetComponent<PlayerInput>().DeactivateInput();
        SceneManager.LoadScene("Combat");
        if(boss == "b")
            GameObject.Find("MC").GetComponent<MCStats>().b = -1;
        if (boss == "dd")
            GameObject.Find("MC").GetComponent<MCStats>().dd = -1;
    }
}
