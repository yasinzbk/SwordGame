using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    public float maxCan = 100f;
    float suankiCan;

    // Start is called before the first frame update
    void Start()
    {
        suankiCan = maxCan;
    }

    public void HasarAl(float miktar)
    {
        suankiCan -= miktar;
        Debug.Log(" Dusman Hasar aldi:  " + miktar + "  Kalan can: " + suankiCan);

        if (suankiCan <= 0)
        {
            Destroy(gameObject);
        }
    }
}
