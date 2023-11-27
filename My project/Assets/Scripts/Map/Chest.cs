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
    public int multiple;

    //consumable//
    public Consumable Bomb = new Consumable("Bomb", "Small bomb that can be thrown for minor damage to the full party.", 70, 0, 0, true);
    public Consumable Potion = new Consumable("Potion", "Basic potion. Heals target for a small amount.", 0, 50, 0, false);
    public Consumable ThrowingKnife = new Consumable("Throwing Knife", "Knife that can be thrown for minor damage to a target.", 100, 0, 0, false);
    public Consumable VialofPureMind = new Consumable("Vial of Pure Mind", "Vial of mysterious origins that restores parties Mana for a small amount.", 0, 0, 75, true);
    public Consumable TearsofDivine = new Consumable("Tears of Time", "Tears of a diety lost to Time. Restores targets Mana for a small amount.", 0, 0, 50, false);
    public Consumable MultiPotion = new Consumable("Multi-Potion", "Large potion that Heals party for a small amount.", 0, 35, 0, true);
    //consumable//

    //equipment//
    public Equipment Axe = new Equipment(0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, "Axe", "Axe");
    public Equipment BattleAxe = new Equipment(0, 0, 0, 25, 0, 0, 0, 0, -5, 0, 0, "Axe", "Battle Axe");
    public Equipment BrigandsAxe = new Equipment(0, 0, 0, 35, 0, 0, 0, 0, 0, 5, 0, "Axe", "Brigand's Axe");
    public Equipment FlatAxe = new Equipment(0, 0, 15, 45, 0, 0, 0, 0, -5, 0, 0, "Axe", "Flat Axe");
    public Equipment Executioner = new Equipment(0, 0, 0, 55, 0, 0, 0, 0, -15, 10, 15, "Axe", "The Executioner");
    //equipment//


    void RandomConsumable()
    {
        switch ((int)Random.Range(0, 5))
        {
            default:
                break;
            case 0:
                consumable = Bomb;
                break;
            case 1:
                consumable = Potion;
                break;
            case 2:
                consumable = ThrowingKnife;
                break;
            case 3:
                consumable = VialofPureMind;
                break;
            case 4:
                consumable = TearsofDivine;
                break;
            case 5:
                consumable = MultiPotion;
                break;
        }
    }

    void RandomEquipment()
    {
        switch ((int)Random.Range(0, 4))
        {
            default:
                break;
            case 0:
                equipment = Axe;
                break;
            case 1:
                equipment = BattleAxe;
                break;
            case 2:
                equipment = BrigandsAxe;
                break;
            case 3:
                equipment = FlatAxe;
                break;
            case 4:
                equipment = Executioner;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomConsumable();

        RandomEquipment();

        Debug.Log(consumable.Name);
        Debug.Log(equipment.Name);
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
                    for (int j = 0; j < multiple; j++)
                    MC.GetComponent<CharStats>().Consumables.Add(consumable, 1);
                }
                if (equipment != null)
                {
                    MC.GetComponent<CharStats>().Equipped.Add(equipment);
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
