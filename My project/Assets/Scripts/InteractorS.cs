using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class InteractorS : MonoBehaviour
{
    public Transform InteractorSource;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Ray r = new Ray(InteractorSource.transform.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hit, range)) 
            { 
                if(hit.collider.gameObject.TryGetComponent(out IInteractable interactobj))
                {
                    interactobj.Interact();
                }
            }
        }
    }
}
