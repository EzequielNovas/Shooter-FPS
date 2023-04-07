using UnityEngine;
public class weaponsController : MonoBehaviour
{
    public WeaponLogic[] weapons;
    public GameObject weapon1, weapon2;
    private int currentWeapon = 0;
    void FixedUpdate() => CheckWeaponChange();
    private void ChangeCurrentWeapon()
    {
      for(int i = 0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        weapons[currentWeapon].gameObject.SetActive(true);
    }
   void CheckWeaponChange()
    {
        //It is used to change the weapon with the mouse wheel

        float ruedaMouse = Input.GetAxis("Mouse ScrollWheel");
        if (ruedaMouse > 0f)
        {
            SelectPreviousWeapon();
            weapons[currentWeapon].reloading   = false;
            weapons[currentWeapon].timeNoShoot = false;
            weapons[currentWeapon].isADS       = false;
        }
        else if (ruedaMouse < 0f)
        {
            SeleccionarArmaSiguiente();
            weapons[currentWeapon].reloading   = false;
            weapons[currentWeapon].timeNoShoot = false;
            weapons[currentWeapon].isADS       = false;
        }

        //and this to change the weapons with the numbers of the keyboard

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            weapons[currentWeapon].reloading   = false;
            weapons[currentWeapon].timeNoShoot = false;
            weapons[currentWeapon].isADS       = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            weapons[currentWeapon].reloading   = false;
            weapons[currentWeapon].timeNoShoot = false;
            weapons[currentWeapon].isADS       = false;
        }
    }
    void SelectPreviousWeapon()
    {
        if(currentWeapon == 0)
            currentWeapon = weapons.Length - 1;
        else
            currentWeapon--;
        ChangeCurrentWeapon();
    }
    void SeleccionarArmaSiguiente()
    {
        if(currentWeapon >=(weapons.Length - 1))
        currentWeapon = 0;
        else
        currentWeapon++;
        ChangeCurrentWeapon(); 
    }
}
