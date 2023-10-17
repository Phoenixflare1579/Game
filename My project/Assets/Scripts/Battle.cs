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
    public int BattleCounter;
    public Rigidbody rb;
    int interval = 1;
    float nextTime = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BattleCounter = 15 + Random.Range(0, 10);
    }
    private void Update()
    {
        if (Time.time >= nextTime)
        {
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
                GetComponent<Animator>().SetInteger("Weapon", 1);
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<PlayerInput>().DeactivateInput();
                SceneManager.LoadScene("Combat");
                BattleCounter = 15 + Random.Range(0, 10);
            }
            nextTime += interval;
        }
    }
}
