using UnityEngine;
using UnityEngine.UI;
public class ScreenBullets : MonoBehaviour
{
    public Text Text;
    public WeaponLogic weaponLogic;
    void Update() => Text.text = weaponLogic.bulletsInCartridge + "/" + weaponLogic.cartridgeSize + "\n" + weaponLogic.remainingBullets;
}
