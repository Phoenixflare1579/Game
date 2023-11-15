using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveStation : MonoBehaviour
{
    GameObject MC;
    public GameObject savemenu;
    GameObject save;
    private void Start()
    {
        MC=GameObject.Find("MC");
    }
    // Update is called once per frame
    void Update()
    {
        save = GameObject.Find(savemenu.name);
        if (Vector3.Distance(MC.transform.position, this.gameObject.transform.position) <= 50.0f)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (save==null)
                Instantiate(savemenu);
            }
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            if (save != null)
                Destroy(savemenu);
        }
    }
}
