using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float valor = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RecibirDa�o(float da�o)
    {
        valor -= da�o;
        if (valor < 0)
        {
            valor = 0;
        }
    }
}


