using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.WSA;

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

       
    }

    public void onClick()
    {

        if (MC.Consumables.ContainsKey("Bomb") && MC.Consumables["Bomb"] > 0)
        {
            BombButton.SetActive(true);
            BombButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ("Bomb: " + MC.Consumables["Bomb"]);
        }
        else
        {
            BombButton.SetActive(false);
        }
        if (MC.Consumables.ContainsKey("Potion") && MC.Consumables["Potion"] > 0)
        {
            PotionButton.SetActive(true);
            PotionButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ("Potion: " + MC.Consumables["Potion"]);
        }
        else
        {
            PotionButton.SetActive(false);
        }

        if (MC.Consumables.ContainsKey("MultiPotion") && MC.Consumables["MultiPotion"] > 0)
        {
            MultiPotionButton.SetActive(true);
            MultiPotionButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ("MultiPotion: " + MC.Consumables["MultiPotion"]);

        }
        else
        {
            MultiPotionButton.SetActive(false);
        }
        if (MC.Consumables.ContainsKey("ThrowingKnife") && MC.Consumables["ThrowingKnife"] > 0)
        {
            KinfeButton.SetActive(true);
            KinfeButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ("ThrowingKnife: " + MC.Consumables["ThrowingKnife"]);
        }
        else
        {
            KinfeButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemMenu.activeSelf)
        {
            if (MC.Consumables.ContainsKey("Bomb") && MC.Consumables["Bomb"] > 0)
            {
                BombButton.SetActive(true);
                BombButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ("Bomb: " + MC.Consumables["Bomb"]);
            }
            else
            {
                BombButton.SetActive(false);
            }
            if (MC.Consumables.ContainsKey("Potion") && MC.Consumables["Potion"] > 0)
            {
                PotionButton.SetActive(true);
                PotionButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ("Potion: " + MC.Consumables["Potion"]);
            }
            else
            {
                PotionButton.SetActive(false);
            }

            if (MC.Consumables.ContainsKey("MultiPotion") && MC.Consumables["MultiPotion"] > 0)
            {
                MultiPotionButton.SetActive(true);
                MultiPotionButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ("MultiPotion: " + MC.Consumables["MultiPotion"]);

            }
            else
            {
                MultiPotionButton.SetActive(false);
            }
            if (MC.Consumables.ContainsKey("ThrowingKnife") && MC.Consumables["ThrowingKnife"] > 0)
            {
                KinfeButton.SetActive(true);
                KinfeButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ("Knife: " + MC.Consumables["ThrowingKnife"]);
            }
            else
            {
                KinfeButton.SetActive(false);
            }
        }
    }
}
