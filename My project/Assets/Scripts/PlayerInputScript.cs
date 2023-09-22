using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ExampleClass : MonoBehaviour
{
    public PlayerInput MyInput;
    public InputActionAsset MyMap;
    public Rigidbody rb;
    public float speed = 3.0f;
    public Vector2 lastDirection;

    void Start()
    {
        
        MyInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
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
            Debug.Log("Walk");
            lastDirection = c.ReadValue<Vector2>();
        }
        else if(c.canceled)
        {
            Debug.Log("Stop Walk");
            lastDirection = Vector2.zero;
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
