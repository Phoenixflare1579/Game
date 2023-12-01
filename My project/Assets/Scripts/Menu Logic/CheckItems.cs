using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItems : MonoBehaviour
{
    public GameObject BombButton;
    public GameObject PotionButton;
    public GameObject MultiPotionButton;
    public GameObject KinfeButton;

    public GameObject ItemMenu;

    PlayerStats MC;
    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("MC").GetComponent<PlayerStats>();

        if (ItemMenu.activeSelf)
        {
            if (MC.Consumables.ContainsKey("Bomb") && MC.Consumables["Bomb"] > 0)
            {
                BombButton.SetActive(true);
            }
            else
            {
                BombButton.SetActive(false);
            }
            if (MC.Consumables.ContainsKey("Potion") && MC.Consumables["Potion"] > 0)
            {
                PotionButton.SetActive(true);
            }
            else
            {
                PotionButton.SetActive(false);

            }

            if (MC.Consumables.ContainsKey("MultiPotion") && MC.Consumables["MultiPotion"] > 0)
            {
                MultiPotionButton.SetActive(true);
            }
            else
            {
                MultiPotionButton.SetActive(false);
            }
            if (MC.Consumables.ContainsKey("ThrowingKnife") && MC.Consumables["ThrowingKnife"] > 0)
            {
                KinfeButton.SetActive(true);
            }
            else
            {
                KinfeButton.SetActive(false);
            }
        }
    }

    public void onClick()
    {

        if (MC.Consumables.ContainsKey("Bomb") && MC.Consumables["Bomb"] > 0)
        {
            BombButton.SetActive(true);
        }
        else
        {
            BombButton.SetActive(false);
        }
        if (MC.Consumables.ContainsKey("Potion") && MC.Consumables["Potion"] > 0)
        {
            PotionButton.SetActive(true);
        }
        else
        {
            PotionButton.SetActive(false);

        }

        if (MC.Consumables.ContainsKey("MultiPotion") && MC.Consumables["MultiPotion"] > 0)
        {
            MultiPotionButton.SetActive(true);
        }
        else
        {
            MultiPotionButton.SetActive(false);
        }
        if (MC.Consumables.ContainsKey("ThrowingKnife") && MC.Consumables["ThrowingKnife"] > 0)
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
