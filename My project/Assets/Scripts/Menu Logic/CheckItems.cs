using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItems : MonoBehaviour
{
    public GameObject BombButton;
    public GameObject PotionButton;
    public GameObject MultiPotionButton;
    public GameObject KinfeButton;


    PlayerStats MC;
    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("MC").GetComponent<PlayerStats>();
    }

    public void onClick()
    {
        Debug.Log("test");

        if (MC.Consumables.ContainsKey("Bomb"))
        {
            BombButton.SetActive(true);
        }
        else
        {
            BombButton.SetActive(false);
        }


        if (MC.Consumables.ContainsKey("Potion"))
        {
            PotionButton.SetActive(true);
        }
        else
        {
            PotionButton.SetActive(false);

        }

        if (MC.Consumables.ContainsKey("MultiPotion"))
        {
            MultiPotionButton.SetActive(true);
        }
        else
        {
            MultiPotionButton.SetActive(false);
        }

        if (MC.Consumables.ContainsKey("ThrowingKnife"))
        {
            KinfeButton.SetActive(true);
        }
        else
        {
            KinfeButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
