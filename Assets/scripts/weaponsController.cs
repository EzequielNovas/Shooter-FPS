using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsController : MonoBehaviour
{
    public weaponLogic[] armas;
    private int indiceDeArmaActual = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RevisarCambioDeArma();

    }
    private void CambiarArmaActual()
    {
      for(int i = 0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        armas[indiceDeArmaActual].gameObject.SetActive(true);
    }
   void RevisarCambioDeArma()
    {
        float ruedaMouse = Input.GetAxis("Mouse ScrollWheel");
        if (ruedaMouse > 0f)
        {
            SeleccionarArmaAnterior();
            armas[indiceDeArmaActual].recargando = false;
            armas[indiceDeArmaActual].tiempoNoDisparo = false;
        }
        else if (ruedaMouse < 0f)
        {
            SeleccionarArmaSiguiente();
            armas[indiceDeArmaActual].recargando = false;
            armas[indiceDeArmaActual].tiempoNoDisparo = false;

        }
    }
    void SeleccionarArmaAnterior()
    {
        if(indiceDeArmaActual == 0)
        {
            indiceDeArmaActual = armas.Length - 1;
        }
        else
        {
            indiceDeArmaActual--;
        }
        CambiarArmaActual();
    }
    void SeleccionarArmaSiguiente()
    {
        if(indiceDeArmaActual >=(armas.Length - 1))
        {
            indiceDeArmaActual = 0;
        }
        else
        {
            indiceDeArmaActual++;
        }
        CambiarArmaActual(); 
    }
}
