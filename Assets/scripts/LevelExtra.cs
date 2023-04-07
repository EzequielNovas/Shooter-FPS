using UnityEngine;
using UnityEngine.UI;
public class LevelExtra : MonoBehaviour
{
    public WeaponLogic[] weapons;
    public Score score;
    public Text round;
    public Text roundmax;
    public HP hpPlayer;
    public GameObject HUD;
    public int selectedWeapon = 0;
    public int rounds;

    void Start()
    {
        SelectWeapon();
        score.value   = 0;
        roundmax.text = "Round record: " + PlayerPrefs.GetInt("RoundMax", 0).ToString();
    }

    void Update()
    {
        round.text = "round " + rounds;
        int previusWeapon = selectedWeapon;
        if (score.value == 5)
        {
            if (selectedWeapon >= weapons.Length - 1)
            {
                weapons[selectedWeapon].reloading      = false;
                weapons[selectedWeapon].timeNoShoot = false;
                weapons[selectedWeapon].isADS         = false;
                selectedWeapon = 0;
            }
            else
            {
                weapons[selectedWeapon].reloading      = false;
                weapons[selectedWeapon].timeNoShoot = false;
                weapons[selectedWeapon].isADS         = false;
                selectedWeapon++;
            }

            score.value = 0;
            rounds++;

            if (hpPlayer.value <= 100)
            {
                hpPlayer.value += 50;

                if (hpPlayer.value >= 100)
                    hpPlayer.value  = 100;
            }

            if (rounds > PlayerPrefs.GetInt("RoundMax", 0))
            {
                PlayerPrefs.SetInt("RoundMax", rounds);
                roundmax.text = rounds.ToString();
            }
        }
        if (previusWeapon != selectedWeapon)
            SelectWeapon();
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if (i == selectedWeapon)
                    weapon.gameObject.SetActive(true);
                else
                    weapon.gameObject.SetActive(false);
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
