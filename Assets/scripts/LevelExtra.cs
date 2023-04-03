using UnityEngine;
using UnityEngine.UI;

public class LevelExtra : MonoBehaviour
{
    public WeaponLogic[] weapons;
    public int selectedWeapon = 0;
    public int rounds;
    public Score score;
    public Text round;
    public Text roundmax;
    public HP hpPlayer;

    public GameObject HUD;
    void Start()
    {
        SelectWeapon();
        score.valor = 0;
        roundmax.text = "Round record: " + PlayerPrefs.GetInt("RoundMax", 0).ToString();
    }

    void Update()
    {
        round.text = "round " + rounds;
        int previusWeapon = selectedWeapon;
        if (score.valor == 5)
        {
            if (selectedWeapon >= weapons.Length - 1)
            {
                weapons[selectedWeapon].recargando = false;
                weapons[selectedWeapon].tiempoNoDisparo = false;
                weapons[selectedWeapon].estaADS = false;
                selectedWeapon = 0;
            }
            else
            {
                weapons[selectedWeapon].recargando = false;
                weapons[selectedWeapon].tiempoNoDisparo = false;
                weapons[selectedWeapon].estaADS = false;
                selectedWeapon++;
            }
            score.valor = 0;
            rounds++;
            if (hpPlayer.valor <= 100)
            {
                hpPlayer.valor += 50;
                if (hpPlayer.valor >= 100)
                    hpPlayer.valor = 100;
            }


            if (rounds > PlayerPrefs.GetInt("RoundMax", 0))
            {

                PlayerPrefs.SetInt("RoundMax", rounds);
                roundmax.text = rounds.ToString();
            }
        }
        if (previusWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if (i == selectedWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
                i++;
            }
        }
    }
    public void ResetRecord()
    {
        PlayerPrefs.DeleteKey("RoundMax");
        roundmax.text = "Round record: 0";
    }
}
