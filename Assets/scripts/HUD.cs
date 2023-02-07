using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text Text;
    public weaponLogic weaponLogic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = weaponLogic.balasEnCartucho + "/" + weaponLogic.tamañoDeCartcho + "\n" + weaponLogic.balasRestantes;
    }
}
