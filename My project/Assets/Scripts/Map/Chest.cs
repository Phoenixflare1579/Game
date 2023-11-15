using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chest : MonoBehaviour
{
    GameObject MC;
    int i = 0;
    public Consumable consumable;
    public Equipment equipment;
    public Sprite open;
    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("MC");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(MC.transform.position, this.gameObject.transform.position) <= 50.0f && i==0)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (consumable != null) 
                {
                    MC.GetComponent<CharStats>().Consumables.Add(consumable, true);
                }
                if (equipment != null)
                {
                    MC.GetComponent<CharStats>().Equipped.Append(equipment);
                }
                i++;
                GetComponent<SpriteRenderer>().sprite = open;
            }
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
