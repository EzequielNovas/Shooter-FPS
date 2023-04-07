using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{ 
    public float value;
    public Score score;
    public Text text;
    public GameObject victoryMenu;
    public MusicManager musicManager;
    public int poinsToWin = 15;
    public GameObject HUD;

    void Start() => score.value = 0;
    void Update()
    {
        text.text = "Score " + score.value;

        if (score.value >= poinsToWin)
           Invoke("Victory", 0.5f);
    }
    public void Victory()
    {
        victoryMenu.SetActive(true);
        musicManager.SwitchMusic(enabled);
        HUD.SetActive(false);
        Time.timeScale   = 0;
        Cursor.visible   = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
