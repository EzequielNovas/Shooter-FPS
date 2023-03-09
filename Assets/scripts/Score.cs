using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float valor;
    public Score score;
    public Text text;

    void Start()
    {
        valor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score " + score.valor;
    }
}
