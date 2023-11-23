using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{

    public void SkillTreeSpawn()
    {
        gameObject.transform.parent.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.black;
        gameObject.transform.parent.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        gameObject.transform.parent.transform.GetChild(8).gameObject.SetActive(true);
    }
    public void Remove()
    {
        gameObject.transform.parent.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
        gameObject.transform.parent.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        gameObject.transform.parent.transform.GetChild(8).gameObject.SetActive(false);
    }
}
