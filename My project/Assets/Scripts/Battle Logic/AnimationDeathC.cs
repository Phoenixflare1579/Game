using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDeathC : MonoBehaviour
{
    int T = 0;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
    void FixedUpdate()
    {
        T++;
        if (T >= 700)
        {
            Destroy(this.gameObject);
        }
    }
}
