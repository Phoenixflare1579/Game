using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EnterBossFight : MonoBehaviour
{
    GameObject MC;
    public string boss;
    private void Start()
    {
        MC = GameObject.Find("MC");
    }
    private void Update()
    {
        if(boss == "b" && MC.GetComponent<MCStats>().b == 1)
        {
            Destroy(this.gameObject);
        }
        if (boss == "dd" && MC.GetComponent<MCStats>().dd == 1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        MC.GetComponent<MCStats>().Location = MC.gameObject.transform.position;
        MC.GetComponent<MCStats>().scene = SceneManager.GetActiveScene().name;
        MC.GetComponent<Animator>().SetInteger("Weapon", 1);
        MC.GetComponent<Rigidbody>().useGravity = false;
        MC.GetComponent<PlayerInput>().DeactivateInput();
        SceneManager.LoadScene("Boss Combat");
        GameObject.Find("Battle").GetComponent<BossBattleStartUp>().boss = boss;
    }
}
