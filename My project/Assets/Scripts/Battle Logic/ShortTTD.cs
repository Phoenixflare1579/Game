using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortTTD : MonoBehaviour
{
    int T = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        T++;
        if (T >= 70)
        {
            Destroy(this.gameObject);
        }
    }
}
