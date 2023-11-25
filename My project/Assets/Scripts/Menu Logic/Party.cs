using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    GameObject MC;
    GameObject Krys;
    GameObject Johanna;
    public int positionM=-1;
    public int positionK=-1;
    public int positionJ=-1;
    // Start is called before the first frame update
    void Start()
    {
        MC=GameObject.Find("MC");
        Krys = GameObject.Find("Krys");
        Johanna = GameObject.Find("Johanna");
    }

    // Update is called once per frame
    void Update()
    {
        if (positionK != -1 && positionK < 4)
        {
            Krys.SetActive(true);
            Krys.GetComponent<CharStats>().position=positionK;
        }
        else if (positionK != -1 && positionK > 4)
        {
            Krys.SetActive(false);
            Krys.GetComponent<CharStats>().position = 3;
        }
        if (positionM != -1 && positionM < 4)
        {
            MC.SetActive(true);
            MC.GetComponent<CharStats>().position = positionM;
        }
        else if (positionM != -1 && positionM > 4)
        {
            MC.SetActive(false);
            MC.GetComponent<CharStats>().position = 3;
        }
        if (positionJ != -1 && positionJ < 4)
        {
            Johanna.SetActive(true);
            Johanna.GetComponent<CharStats>().position = positionJ;
        }
        else if (positionJ != -1 && positionJ > 4)
        {
            Johanna.SetActive(false);
            Johanna.GetComponent<CharStats>().position = 3;
        }
        if (positionJ > 4 && positionK > 4 && positionM > 4)
        {
            MC.SetActive(true);
            MC.GetComponent<CharStats>().position = 0;
            positionM = 0;
        }
    }
}
