using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ExampleClass : MonoBehaviour
{
    public PlayerInput MyInput;
    public InputActionAsset MyMap;
    public Rigidbody rb;
    public float speed = 100f;
    public Vector2 lastDirection;
    public Animator animator;
    public GameObject menu;
    int i = 0;
    void Start()
    {
        Debug.Log("PlayerInput");
        MyInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
        if (MyInput != null )
        {
            MyMap = MyInput.actions;
        }
        if ( rb != null )
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        rb.velocity = new Vector3(lastDirection.x,0,lastDirection.y).normalized * speed + new Vector3(0,Physics.gravity.y,0)*3;
    }

    public void Move(InputAction.CallbackContext c)
    {
        if(c.performed)
        {
            if (c.ReadValue<Vector2>().x < 0)
            {
                if (GetComponent<SpriteRenderer>() != null)
                    GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                if (GetComponent<SpriteRenderer>() != null)
                    GetComponent<SpriteRenderer>().flipX = false;
            }
            lastDirection = c.ReadValue<Vector2>();
            animator.SetBool("Walk", true);
        }
        else if(c.canceled)
        {
            lastDirection = Vector2.zero;
            animator.SetBool("Walk", false);
        }
    } 

    public void Sprint(InputAction.CallbackContext c) 
    { 
       if (c.performed) 
       {
            speed *= 2.0f;
       }
       else if (c.canceled)
       {
            speed /= 2.0f;
       }
    }

    public void Menu(InputAction.CallbackContext c) 
    {
        if (GameObject.Find("PauseParent") != null)
        {
            menu = GameObject.Find("PauseParent").gameObject.transform.GetChild(0).gameObject;
            Debug.Log(menu.name);
            if (c.started)
            {
                if (i == 0)
                {
                    menu.SetActive(true);
                    i++;
                }
                else
                {
                    menu.SetActive(false);
                    i--;
                }
            }
        }
    }
}
