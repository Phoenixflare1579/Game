using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject items;
    public Canvas Canvas;
    GameObject holder;
    GameObject MC;
    private void Start()
    {
        MC = GameObject.Find("MC");
    }
    public void MakeInventory()
    {
        for (int i = 0; i < MC.GetComponent<PlayerStats>().Consumables.Keys.ToArray().Length; i++) 
        {
            holder = Instantiate(items, Canvas.transform);
            holder.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = MC.GetComponent<PlayerStats>().Consumables.Keys.ToArray()[i];
        }
        gameObject.transform.parent.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.black;
    }
    public void Remove()
    {
        for(int i =0; i < Canvas.transform.childCount; i++)
        {
            Destroy(Canvas.transform.GetChild(i).gameObject);
        }
        gameObject.transform.parent.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
    }
}
