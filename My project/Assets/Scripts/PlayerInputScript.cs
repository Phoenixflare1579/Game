using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ExampleClass : MonoBehaviour
{
    public PlayerInput MyInput;
    public InputActionAsset MyMap;
    public Rigidbody rb;
    public float speed = 100f;
    public Vector2 lastDirection;
    public Animator animator;

    void Start()
    {
        
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
        rb.velocity = new Vector3(lastDirection.x,0,lastDirection.y).normalized*speed + new Vector3(0, rb.velocity.y, 0);
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
            Debug.Log("Walk");
            lastDirection = c.ReadValue<Vector2>();
            animator.SetBool("Walk", true);
        }
        else if(c.canceled)
        {
            Debug.Log("Stop Walk");
            lastDirection = Vector2.zero;
            animator.SetBool("Walk", false);
        }
    } 

    public void Sprint(InputAction.CallbackContext c) 
    { 
       if (c.performed) 
       {
            Debug.Log("Sprint");
            speed *= 2.0f;
        }
       else if (c.canceled)
        {
            Debug.Log("Stop Sprint");
            speed /= 2.0f;
        }
    }

    public void Menu(InputAction.CallbackContext c) 
    { 
       if (c.started)
        {
            Debug.Log("Pause");
            SceneManager.LoadScene("Main Menu");
        }
    
    
    }
    public void Mover(InputAction.CallbackContext c) 
    { 
     if(c.performed) 
        { 
          Debug.Log("New Vector 2 based on controls: " + c.action.ReadValue<Vector2>());
        }
    }
    
}
