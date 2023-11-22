using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesS : MonoBehaviour
{
    PlayerStats Char;

    private void Update()
    {
        if (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuKrysS>() != null)
        Char = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuKrysS>().Krys.GetComponent<PlayerStats>();
        else if (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuMCS>() != null)
        Char = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InputMenuMCS>().MC.GetComponent<PlayerStats>();
    }
    public void Ability()
    {
        this.gameObject.transform.GetChild(Char.Form).gameObject.SetActive(true);
    }
}
