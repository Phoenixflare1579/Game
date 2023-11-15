using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Battle : MonoBehaviour
{
    public int Movement=0;
    public int BattleCounter=5;
    public Rigidbody rb;
    private IEnumerator coroutine;
    public GameObject MC;
    public int S = 0;
    int i = 0;

    void Start()
    {
        BattleCounter = 10 + Random.Range(0, 15);
        coroutine = WaitAndPrint(1.0f);
        MC = GameObject.Find("MC");
        rb = MC.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (i == 0 && S==0)
        {
            StartCoroutine(coroutine);
            i++;
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            if (rb.velocity.x > .1f && S==0)
            {
                Movement++;
                if (rb.velocity.x >= 150)
                {
                    Movement++;
                }
            }
            if (Movement >= BattleCounter)
            {
                MC.GetComponent<MCStats>().Location = MC.gameObject.transform.position;
                Movement = 0;
                BattleCounter = 10 + Random.Range(0, 15);
                MC.GetComponent<Animator>().SetInteger("Weapon", 1);
                MC.GetComponent<Rigidbody>().useGravity = false;
                MC.GetComponent<PlayerInput>().DeactivateInput();
                SceneManager.LoadScene("Combat");
                StopCoroutine(coroutine);
                S = 1;
                i = 0;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    public void Safe()
    {
        S = 1;
    }
    public void UnSafe()
    {
        S = 0;
    }
}
