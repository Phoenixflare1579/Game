using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Battle : MonoBehaviour
{
    public int Movement=0;
    public int Timer = 0;
    public int BattleCounter=5;
    public Rigidbody rb;
    int interval = 1;
    float nextTime = 0;
    private IEnumerator coroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BattleCounter = 3 + Random.Range(0, 10);
        coroutine = WaitAndPrint(1.0f);
        StartCoroutine(coroutine);
    }
    private void Update()
    {
        
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            Debug.Log(Movement);
            if (rb.velocity.magnitude > 0)
            {
                Timer++;
                if (Timer <= 60)
                {
                    Timer = 0;
                    Movement++;
                    if (rb.velocity.magnitude >= 150)
                    {
                        Movement++;
                    }
                }
            }
            if (Movement >= BattleCounter)
            {
                Movement = 0;
                Timer = 0;
                BattleCounter = 15 + Random.Range(0, 10);
                GetComponent<Animator>().SetInteger("Weapon", 1);
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<PlayerInput>().DeactivateInput();
                SceneManager.LoadScene("Combat");
                StopCoroutine(coroutine);
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
