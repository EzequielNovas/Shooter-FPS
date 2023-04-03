
using UnityEngine;

public class weaponsController : MonoBehaviour
{
    public WeaponLogic[] weapons;
    public GameObject weapon1, weapon2;
    private int indiceDeArmaActual = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        RevisarCambioDeArma();
    }
    private void CambiarArmaActual()
    {
      for(int i = 0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        weapons[indiceDeArmaActual].gameObject.SetActive(true);
    }
   void RevisarCambioDeArma()
    {
        //It is used to change the weapon with the mouse wheel

        float ruedaMouse = Input.GetAxis("Mouse ScrollWheel");
        if (ruedaMouse > 0f)
        {
            SeleccionarArmaAnterior();
            weapons[indiceDeArmaActual].recargando = false;
            weapons[indiceDeArmaActual].tiempoNoDisparo = false;
            weapons[indiceDeArmaActual].estaADS = false;

        }
        else if (ruedaMouse < 0f)
        {
            SeleccionarArmaSiguiente();
            weapons[indiceDeArmaActual].recargando = false;
            weapons[indiceDeArmaActual].tiempoNoDisparo = false;
            weapons[indiceDeArmaActual].estaADS = false;
        }

        //and this to change the weapons with the numbers of the keyboard

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            weapons[indiceDeArmaActual].recargando = false;
            weapons[indiceDeArmaActual].tiempoNoDisparo = false;
            weapons[indiceDeArmaActual].estaADS = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            weapons[indiceDeArmaActual].recargando = false;
            weapons[indiceDeArmaActual].tiempoNoDisparo = false;
            weapons[indiceDeArmaActual].estaADS = false;
        }
    }
    void SeleccionarArmaAnterior()
    {
        if(indiceDeArmaActual == 0)
        {
            indiceDeArmaActual = weapons.Length - 1;
        }
        else
        {
            indiceDeArmaActual--;
        }
        CambiarArmaActual();
    }
    void SeleccionarArmaSiguiente()
    {
        if(indiceDeArmaActual >=(weapons.Length - 1))
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
