using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenHP : MonoBehaviour
{
    private Slider slider;
    public Text text;
    public HP hp;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }


    private void Update()
    {
        text.text = hp.valor + "/100";
    }

}
